using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailService.EmailServices.Entities;
using MailService.EmailServices.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MISA.ApplicationCore.EmailServices.Services;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using ScheduledTask.Jobs;
using ScheduledTask.Schedule;

namespace ScheduledTask
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy", builder => builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
        );
      });

      services.AddHttpContextAccessor();

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
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:AccessTokenSecret"])),
                ValidateIssuer = false,
                ValidateAudience = false
              };
              x.Events = new JwtBearerEvents
              {
                OnMessageReceived = context =>
                {
                  var accessToken = context.Request.Query["access_token"];

                  // If the request is for our hub...
                  var path = context.HttpContext.Request.Path;
                  if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/notification")))
                  {
                    // Read the token out of the query string
                    context.Token = accessToken;
                  }
                  return Task.CompletedTask;
                }
              };
            });

      services.AddSignalR(options => {
        options.EnableDetailedErrors = true;
      });

      // Cấu hình email config
      var emailConfig = Configuration
          .GetSection("EmailConfiguration")
          .Get<EmailConfiguration>();
      services.AddSingleton(emailConfig);

      services.AddControllers();

      // Thực hiện DI cho mail service
      services.AddSingleton<IEmailSender, EmailSender>();

      services.AddHostedService<ScheduledHostedService>();
      services.AddSingleton<IJobFactory, JobFactory>();
      services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

      services.AddSingleton<TaskJob>();
      List<Library.Entities.JobData> jobDatas = new List<Library.Entities.JobData>();
      jobDatas.Add(new Library.Entities.JobData(Guid.NewGuid(), typeof(TaskJob), "Task job", "0/10 0/1 * 1/1 * ?")); // Mỗi 30s

      services.AddSingleton(jobDatas);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseCors("CorsPolicy");

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGet("/", async context =>
        {
          await context.Response.WriteAsync("Hello World!");
        });

        endpoints.MapHub<NotifyHub>("/notification");
      });
    }
  }
}
