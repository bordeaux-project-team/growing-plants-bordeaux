using System.Text;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.BusinessLogic.Services;
using GrowingPlants.BusinessLogic.UnitOfWorks;
using GrowingPlants.DataAccess.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

namespace GrowingPlants.Apis
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//Allow headers
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", builder =>
				{
					builder
						.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod();
				});
			});

			services.AddControllers();
			services.AddSingleton(Configuration);
			services.AddDbContext<GrowingPlantsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GrowingPlantsDb")));

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ITreeService, TreeService>();
			services.AddScoped<IPlantingEnvironmentService, PlantingEnvironmentService>();
			services.AddScoped<IMeasurementUnitService, MeasurementUnitService>();
			services.AddScoped<IPlantingProcessService, PlantingProcessService>();
			services.AddScoped<ICountryService, CountryService>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			var secretKey = Encoding.ASCII.GetBytes(Configuration["Secret"]);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(x =>
				{
					x.RequireHttpsMetadata = false;
					x.SaveToken = true;
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(secretKey),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "GrowingPlants", Version = "v1" });
				var securitySchema = new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				};
				c.AddSecurityDefinition("Bearer", securitySchema);
				c.AddSecurityRequirement(new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, GrowingPlantsContext context)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseCors("AllowAll");

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "GrowingPlants APIs");
			});

			loggerFactory.AddSerilog();
			loggerFactory.AddFile("Logs/log.txt");

			context.Database.Migrate();
		}
	}
}
