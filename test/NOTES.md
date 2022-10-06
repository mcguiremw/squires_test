- Building and running the containers takes over 10min
- Needed to run docker compose build 2x before api available
- All endpoints return 401 on all requests

Logs from container app_code_api
```info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/1.1 GET http://localhost:8100/api/City
info: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService[2]
      Authorization failed.
info: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler[12]
      AuthenticationScheme: Bearer was challenged.
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished in 2.6459ms 401
```

Not running at the moment, not seeing configs as something importable.

command to run would be from the `test/` directory

`pipenv run pytest`