using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ScheduledTask
{
  public class NotifyHub : Hub
  {
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public override Task OnConnectedAsync()
    {
      var user = new Library.Entities.Employee()
      {
        ConectionID = Context.ConnectionId,
        ID = long.Parse(SessionData.UserID),
        FullName = SessionData.FullName,
        Email = SessionData.Email
      };
      SessionData.Clients.Add(user);
      return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
      var dataRemove = SessionData.Clients.Find(x => x.ConectionID == Context.ConnectionId);
      if(dataRemove != null)
      {
        SessionData.Clients.Remove(dataRemove);
      }
      return base.OnDisconnectedAsync(exception);
    }

    public async Task AskServer(Library.Entities.Task task)
    {
      var client = SessionData.Clients.Find(x => x.ID == task.AssignedUserID);
      if (client != null)
      {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data["EventName"] = "ASSIGN_TASK";
        data["Content"] = $"{SessionData.FullName} assigned a task {task.TaskCode} to you!";
        await this.Clients.Client(client.ConectionID).SendAsync("notify", data);
      }
    }
  }
}
