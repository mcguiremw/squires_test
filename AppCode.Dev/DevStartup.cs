using System;
using AppCode.Data;
using AppCode.Dev.Helpers;
using AppCode.Dev.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace AppCode.Dev
{

    public class DevStartup: Startup
    {
        // usually the configuration will be injected, but we're not doing that by default in Startup
        // so we'll have here commented for convenience
        // public DevStartup(IConfiguration configuration): base(configuration)
        // {
        // }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            base.Configure(app, env, loggerFactory);

            #region Swagger

            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.DocumentTitle = "Appcode Assessment Swagger";
                settings.Path = $"{SwaggerRoutes.Controller}";
                settings.DocumentPath = $"{SwaggerRoutes.Controller}/{SwaggerRoutes.JsonSpec}";
            });
            app.UseReDoc(settings =>
            {
                // settings.DocumentTitle = "FSM Swagger";
                settings.Path = $"{SwaggerRoutes.DocBase}/redoc";
                settings.DocumentPath = $"{SwaggerRoutes.Controller}/{SwaggerRoutes.JsonSpec}";
            });
            
            #endregion

            SetupDb(app);
        }

        private void SetupDb(IApplicationBuilder app)
        {
            // Need to use a scope to retrieve a scoped service
            var serviceScope = app.ApplicationServices.GetService<IServiceProvider>().CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<DataContext>();
            
            dbContext.ResetDb();
            serviceScope.Dispose();
        }
    }
}
