using AgileHub.Api.Data;
using AgileHub.Api.Mappings;
using AgileHub.Api.Repositories.PokerPlanning;
using AgileHub.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using AgileHub.Api.Middlewares;
using AgileHub.Api.Repositories.SprintRetro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = new LoggerConfiguration()
    .WriteTo
    .File("Logs/AgileHub_Log.txt", rollingInterval:RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AgileHubDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AgileHubConnectionString")));

builder.Services.AddScoped<IEstimationSystemRepository, SqlEstimationSystemRepository>();
builder.Services.AddScoped<IPlanningRoomRepository, SqlPlanningRoomRepository>();
builder.Services.AddScoped<IStoryRepository, SqlStoryRepository>();
builder.Services.AddScoped<IVoteRepository, SqlVoteRepository>();

builder.Services.AddScoped<IUserRepository, SqlUserRepository>();
builder.Services.AddScoped<IAvatarRepository, SqlAvatarRepository>();

builder.Services.AddScoped<IRetroBoardRepository, SqlRetroBoardRepository>();
builder.Services.AddScoped<IBoardColumnRepository, SqlBoardColumnRepository>();
builder.Services.AddScoped<INoteRepository, SqlNoteRepository>();
builder.Services.AddScoped<ICommentRepository, SqlCommentRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DefaultModelsExpandDepth(-1);
    });
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
