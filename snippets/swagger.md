Quick Look: https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger

**Swagger UI New Version:** https://github.com/swagger-api/swagger-ui/releases

Edit your Startup.cs file with following contents.

**Using**
```csharp
using Swashbuckle.AspNetCore.Swagger;
```

**Swagger Definition**
```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info { Title = "Todo API", Version = "v1" });
    });
}
```

**Documentation (Add to csproj file)**
```xml
<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
  <DocumentationFile>bin\Debug\netcoreapp2.0\Todo.xml</DocumentationFile>
</PropertyGroup>
```

```csharp
// Set the comments path for the Swagger JSON and UI.
var basePath = PlatformServices.Default.Application.ApplicationBasePath;
var xmlPath = Path.Combine(basePath, "Todo.xml"); 
document.IncludeXmlComments(xmlPath);     
```

**Method Descriptions**
```csharp
/// <summary>
/// Add a new todo.
/// </summary>
/// <remarks>Please use the model that we sent you.</remarks>
/// <response code="200">We have created your todo.</response>
/// <response code="400">Your model is invalid</response>
/// <response code="500">Something is wrong on our server. But we don't know what cause it.</response>
[ProducesResponseType(typeof(Return), 200)]
```

**Security Definitions**

```csharp
// Security Definitions
document.AddSecurityDefinition("Client-Id", new ApiKeyScheme
{
    Name = "Client-Id",
    Description = "",
    Type = "apiKey",
    In = "header"
});
document.AddSecurityDefinition("Client-Secret", new ApiKeyScheme
{
    Name = "Client-Secret",
    Description = "",
    Type = "apiKey",
    In = "header"
});
```