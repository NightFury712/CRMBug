using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.BL;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using Infarstructure.Base;
using Infarstructure.Employees;
using Infarstructure.Issues;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
      services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
      {
        builder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
      }));

      services.AddControllers();
      services.AddControllers().AddJsonOptions(jsonOptions =>
      {
        jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
      });
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "BugTracking", Version = "v1" });
      });
      // Thực hiện DI cho base
      services.AddScoped(typeof(IBLBase<>), typeof(BLBase<>));
      services.AddScoped(typeof(IDLBase<>), typeof(DLBase<>));

      // Thực hiện DI cho issue
      services.AddScoped<IBLIssue, BLIssue>();
      services.AddScoped<IDLIssue, DLIssue>();

      // Thực hiện DI cho employee
      services.AddScoped<IBLEmployee, BLEmployee>();
      services.AddScoped<IDLEmployee, DLEmployee>();
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

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
