using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using Library.Constant;
using Library.Entities;
using ToolSupport.Base;

namespace ToolSupport
{
  public partial class MainForm : Form
  {
    /// <summary>
    /// Thực hiện đăng nhập vào hệ thống
    /// Author: hhdang 25.6.2022
    /// </summary>
    public void Login()
    {
      string username = this.txtUsername.Text;
      string password = this.txtPassword.Text;
      var employee = new Employee()
      {
        Username = username,
        Password = Utils.Base64Encode(password)
      };

      client = new SupportToolHttpClient("", true);

      var result = client.Post("Auth/login", employee);
      if(result.Success)
      {
        var data = Utils.Deserialize<Dictionary<string, object>>(result.Data.ToString());
        if(data != null && data.ContainsKey("AccessToken"))
        {
          token = data["AccessToken"]?.ToString();
          this.panelLogin.Visible = false;
        }
      }
    }

    /// <summary>
    /// Thực hiện lấy dữ liệu dự án
    /// Author: hhdang 25.6.2022
    /// </summary>
    public void GetProject()
    {
      client = new SupportToolHttpClient(token);
      var result = client.Get("Project");
      if(result.Success)
      {
        var data = Utils.Deserialize<List<Dictionary<string, object>>>(result.Data.ToString());
        ShowData(this.dgvProject, data);
      } else
      {
        SendNotifyProject(SupportTool.SupportTool_Exception);
      }
    }
    /// <summary>
    /// Thực hiện lấy dữ liệu công việc
    /// Author: hhdang 25.6.2022
    /// </summary>
    public void GetTask()
    {
      client = new SupportToolHttpClient(token);
      var result = client.Get("Task");
      if (result.Success)
      {
        var data = Utils.Deserialize<List<Dictionary<string, object>>>(result.Data.ToString());
        ShowData(this.dgvTask, data);
      }
      else
      {
        SendNotifyProject(SupportTool.SupportTool_Exception);
      }
    }
    /// <summary>
    /// Thực hiện lấy dữ liệu nhân viên
    /// Author: hhdang 25.6.2022
    /// </summary>
    public void GetMember()
    {
      client = new SupportToolHttpClient(token);
      var result = client.Get("Employee");
      if (result.Success)
      {
        var data = Utils.Deserialize<List<Dictionary<string, object>>>(result.Data.ToString());
        ShowData(this.dgvMember, data);
      }
      else
      {
        SendNotifyProject(SupportTool.SupportTool_Exception);
      }
    }
    /// <summary>
    /// Thực hiện lấy dữ liệu nhân viên được thêm vào dự án
    /// Author: hhdang 25.6.2022
    /// </summary>
    public void GetProjectMember()
    {

    }

    public void SendNotifyProject(string msg)
    {
      this.lblNotifyProject.Text = msg;
    }

    public void SendNotifyTask(string msg)
    {
      this.lblNotifyTask.Text = msg;
    }

    public void SendNotifyMember(string msg)
    {
      this.lblNotifyMember.Text = msg;
    }
  }
}
