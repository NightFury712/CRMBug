using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Library;
using Library.Constant;
using MailService.EmailServices.Entities;
using MailService.EmailServices.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Quartz;

namespace ScheduledTask.Jobs
{
  public class TaskJob : IJob
  {
    #region DECLARE
    private readonly IConfiguration _configuration;
    private readonly string _connectionString = string.Empty;
    private readonly IDbConnection _dbConnection = null;
    private readonly IHubContext<NotifyHub> _hub;
    private readonly IEmailSender _emailSender;
    #endregion
    public TaskJob(IConfiguration configuration, IEmailSender emailSender, IHubContext<NotifyHub> hub)
    {
      _configuration = configuration;
      _connectionString = configuration.GetConnectionString("DefaultConnectionString");// chuỗi config kết nối db
      _dbConnection = new MySqlConnection(_connectionString);
      _hub = hub;
      _emailSender = emailSender;
    }

    public Task Execute(IJobExecutionContext context)
    {
      try
      {
        string sql = Constant.Schedule_GetData;
        List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

        using (var rd = _dbConnection.ExecuteReader(sql, commandType: CommandType.Text))
        {
          if (rd != null)
          {
            data = ExtensionMethod.ToListDictionary(rd);
          }
        };
        if (data != null && data.Any())
        {
          this.SaveNotifyToDB(data);

          this.SendNotifyClients(data);
        }
        return Task.CompletedTask;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return Task.CompletedTask;
      }
      
    }


    private void SaveNotifyToDB(List<Dictionary<string, object>> data)
    {
      var ids = string.Join(",", data.Select(x => x["ID"]?.ToString()));
      var insertSQL = new StringBuilder();
      insertSQL.Append("INSERT INTO notification (FromUserID, ToUserID, LayoutCode, EventName, Config, Content, ModifiedDate, ModifiedBy, CreatedDate, CreatedBy, ProjectID) VALUES ");
      var template = Properties.Resources.Schedule_TemplateNotify;
      var dataInsert = new List<string>();
      foreach(var item in data)
      {
        string content = string.Empty;
        string tmpSQL = string.Empty;
        if(item.ValueIsNotNull("TaskCode") && item.ValueIsNotNull("DueDate"))
        {
          content = string.Format(template, item["TaskCode"]?.ToString(), Convert.ToDateTime(item["DueDate"]).Minute - DateTime.Now.Minute);
        }
        if (item.ValueIsNotNull("AssignedUserID") && item.ValueIsNotNull("ProjectID"))
        {
          tmpSQL = $"(null, '{item["AssignedUserID"]}', 'Task', 'REMIND_WORK', '', '{content}', NOW(), 'Schedule Worker', NOW(), 'Schedule Worker', '{item["ProjectID"]}')";
        }
        dataInsert.Add(tmpSQL);
      }
      insertSQL.Append(string.Join(",", dataInsert.Select(x => x)));
      insertSQL.Append($";DELETE FROM schedule WHERE ID IN ({ids});");

      var deleteSql = insertSQL;
      // _ = _dbConnection.Execute(deleteSql, commandType: CommandType.Text);
    }


    private void SendNotifyClients(List<Dictionary<string, object>> data)
    {
      var template = Properties.Resources.Schedule_TemplateNotify;
      foreach (var item in data)
      {
        if (item.ValueIsNotNull("AssignedUserID") && long.TryParse(item["AssignedUserID"].ToString(), out long id))
        {
          var client = SessionData.Clients.Find(x => x.ID == id);
          if (client != null)
          {
            item["EventName"] = "REMIND_WORK";
            this._hub.Clients.Client(client.ConectionID).SendAsync("notify", item);
          }
        }
        
        if(item.ValueIsNotNull("Email") && item.ValueIsNotNull("DueDate"))
        {
          var dueDate = Convert.ToDateTime(item["DueDate"]);
          var minuteLeft = dueDate.Minute - DateTime.Now.Minute;
          var message = new Message(
            new string[] { item["Email"].ToString() },
            "Remind work from task management!", string.Format(template, item["TaskCode"]?.ToString(), minuteLeft)
          );
          _emailSender.SendEmail(message);
        }
      }
    }
  }
}
