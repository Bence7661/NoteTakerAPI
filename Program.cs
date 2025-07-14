using Microsoft.EntityFrameworkCore;
using NoteTakerAPI;
using NoteTakerAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var serviceRegistrator = new ServiceRegistrator(builder);
serviceRegistrator.RegisterServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAllDebug");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
