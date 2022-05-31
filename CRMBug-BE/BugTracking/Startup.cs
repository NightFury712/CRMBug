using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Authentication.JWT.Generators;
using ApplicationCore.BL;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using Infarstructure.Base;
using Infarstructure.Employees;
using Infarstructure.Issues;
using Infarstructure.Projects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BugTracking
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
      services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
      {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
      }));

      services.AddDistributedMemoryCache();

      services.AddSession((optional) =>
      {
        optional.IdleTimeout = TimeSpan.FromMinutes(360); // 360 phút  
      });

      services.AddHttpContextAccessor();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["JwtConfig:Issuer"],
                ValidAudience = Configuration["JwtConfig:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:AccessTokenSecret"]))
              };
            });

      services.AddControllers();
      services.AddControllers().AddJsonOptions(jsonOptions =>
      {
        jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
      });
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "BugTracking", Version = "v1" });
      });

      services.AddSingleton<AccessTokenGenerator>();
      // Thực hiện DI cho auth
      services.AddScoped<IBLAuth, BLAuth>();

      // Thực hiện DI cho base
      services.AddScoped(typeof(IBLBase<>), typeof(BLBase<>));
      services.AddScoped(typeof(IDLBase<>), typeof(DLBase<>));

      // Thực hiện DI cho issue
      services.AddScoped<IBLIssue, BLIssue>();
      services.AddScoped<IDLIssue, DLIssue>();

      // Thực hiện DI cho employee
      services.AddScoped<IBLEmployee, BLEmployee>();
      services.AddScoped<IDLEmployee, DLEmployee>();

      // Thực hiện DI cho project
      services.AddScoped<IBLProject, BLProject>();
      services.AddScoped<IDLProject, DLProject>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BugTracking v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors("ApiCorsPolicy");

      app.UseSession();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
