using Microsoft.OpenApi.Models;
using NoteTakerAPI.Repositories;
using System.Reflection;

namespace NoteTakerAPI;

public class ServiceRegistrator(WebApplicationBuilder builder)
{
    public void RegisterServices()
    {
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddScoped<INotebookRepository, NotebookRepository>();
        builder.Services.AddScoped<INoteRepository, NoteRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        RegisterDevOnlyServices();
    }

    private void RegisterDevOnlyServices()
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NoteTaker API",
                    Version = "v1",
                    Description = "API for my React practice project",
                    Contact = new OpenApiContact
                    {
                        Name = "Serious",
                        Email = "canthavemy@email.com"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllDebug", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}
