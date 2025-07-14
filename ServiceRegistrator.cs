using NoteTakerAPI.Repositories;

namespace NoteTakerAPI;

public static class ServiceRegistrator
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        services.AddScoped<INotebookRepository, NotebookRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
