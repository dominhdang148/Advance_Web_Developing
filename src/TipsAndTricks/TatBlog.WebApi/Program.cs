using TatBlog.WebApi.Extensions;
using TatBlog.WebApi.Mapsters;

var builder = WebApplication.CreateBuilder(args);
{
    builder
        .ConfigureCors()
        .ConfigureNlog()
        .ConfigureServices()
        .ConfigureMapster()
        .ConfigureSwaggerOpenApi();
}

var app = builder.Build();
{
    app.SetupRequestPipeline();
    app.Run();

}



