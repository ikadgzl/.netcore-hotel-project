using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.Configurations;
using HotelProject.Data;
using HotelProject.IRepository;
using HotelProject.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace HotelProject
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
			services.AddTransient<IUnitOfWork, UnitOfWork>();
			services.AddAutoMapper(typeof(MapperInitializer));
			services.AddControllers()
				.AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
			services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "HotelProject", Version = "v1"}); });
			services.AddCors(o =>
			{
				o.AddPolicy("AllowAllPolicy", builder =>
					builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
				);
			});
			services.AddDbContext<AppDbContext>(opt =>
				opt.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnectionString"))
			);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelProject v1"));
			}

			app.UseCors("AllowAllPolicy");

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}