using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;

namespace ScheduledTask.Schedule
{
  public class ScheduledHostedService : IHostedService
  {
    public IScheduler Scheduler { get; set; }
    private readonly ISchedulerFactory _schedulerFactory;
    private readonly IJobFactory _jobFactory;
    private readonly List<Library.Entities.JobData> _jobDatas;

    public ScheduledHostedService(ISchedulerFactory schedulerFactory, List<Library.Entities.JobData> jobDatas, IJobFactory jobFactory)
    {
      this._jobFactory = jobFactory;
      this._schedulerFactory = schedulerFactory;
      this._jobDatas = jobDatas;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      //Creating Schdeular
      Scheduler = await _schedulerFactory.GetScheduler();
      Scheduler.JobFactory = _jobFactory;

      //Suporrt for Multiple Jobs
      _jobDatas?.ForEach(jobData =>
      {
        //Create Job
        IJobDetail jobDetail = CreateJob(jobData);
        //Create trigger
        ITrigger trigger = CreateTrigger(jobData);
        //Schedule Job
        Scheduler.ScheduleJob(jobDetail, trigger, cancellationToken).GetAwaiter();
        //Start The Schedular
      });
      await Scheduler.Start(cancellationToken);
    }

    private ITrigger CreateTrigger(Library.Entities.JobData jobMetadata)
    {
      return TriggerBuilder.Create()
          .WithIdentity(jobMetadata.JobId.ToString())
          .WithCronSchedule(jobMetadata.CronExpression)
          .WithDescription(jobMetadata.JobName)
          .Build();
    }

    private IJobDetail CreateJob(Library.Entities.JobData jobMetadata)
    {
      return JobBuilder.Create(jobMetadata.JobType)
          .WithIdentity(jobMetadata.JobId.ToString())
          .WithDescription(jobMetadata.JobName)
          .Build();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
      await Scheduler.Shutdown();
    }
  }
}
