using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NJsonSchema.Generation;
using NSwag;
using NSwag.Generation.Processors.Security;
using NSwag.Generation.WebApi;

namespace AppCode.Dev.Swagger
{
    public static class SwaggerRoutes
    {
        public const string DocBase = "/doc";
        public const string Controller = DocBase + "/swagger";
        public const string JsonSpec = "spec";
    }
    
    [AllowAnonymous]
    [Route(SwaggerRoutes.Controller)]
    public class SwaggerController: Controller
    {

        public static readonly Lazy<OpenApiDocument> SwaggerSpec = new Lazy<OpenApiDocument>(() =>
        {
            var apiAssembly = typeof(AppCode.Program).Assembly;
            
            var settings = new WebApiOpenApiDocumentGeneratorSettings
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy(false, true)
                    }
                },
                DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull,
                DefaultResponseReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull,
                FlattenInheritanceHierarchy = true,
                GenerateAbstractProperties = true,
                Title = "AppCode Assessment API",
                Version = "1.0.0"
            };
            
            // This sets up having the Authorize button in the Swagger UI to send the authorization along with the requests
            var securityName = "Auth Token";
            settings.OperationProcessors.Add(new OperationSecurityScopeProcessor(securityName));
            settings.AddSecurity(securityName, Enumerable.Empty<string>(),
                new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Copy 'Bearer ' + valid JWT token into field, e.g. if token is 'FOO', then put: 'Bearer FOO' below without any quotes."
                }
            );

            var controllers = WebApiOpenApiDocumentGenerator.GetControllerClasses(apiAssembly);
            var generator = new WebApiOpenApiDocumentGenerator(settings);

            return generator.GenerateForControllersAsync(controllers).Result;
        });
        
        [HttpGet(SwaggerRoutes.JsonSpec)]
        public string GetSwaggerSpec() => SwaggerSpec.Value.ToJson();
    }
}