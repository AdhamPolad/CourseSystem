using CourseSystem.Configs;
using CourseSystem.Middleware;
using CourseSystem.Services.Implementations;
using CourseSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.Json;
using Serilog;
using CourseSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.IdentityModel.Tokens.Jwt;
using CourseSystem.Enum;
using CourseSystem.RepositoriesV2.Implementations;
using CourseSystem.RepositoriesV2.Interfaces;
using CourseSystem.Filter;
using Microsoft.AspNetCore.Mvc;
using CourseSystem.Seeds;
namespace CourseSystem
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IStudentRepository, StudentRepositoryV2>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<ILessonRepository, LessonRepositoryV2>();
            builder.Services.AddScoped<ILessonService, LessonService>();
            builder.Services.AddScoped<IGroupRepository, GroupRepositoryV2>();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<ExceptionHandler>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IFileRepository, FileRepository>();
            builder.Services.AddControllers(opts =>
                 opts.Conventions.Add(new RouteTokenTransformerConvention(new ToKebabParameterTransformer())));

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddDbContext<CourseSystemDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddControllers().AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<DataSeeder>();


            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var context = service.GetRequiredService<CourseSystemDbContext>();
            context.Database.Migrate();
            var dataSeeder = service.GetRequiredService<DataSeeder>();
            dataSeeder.Seed();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
