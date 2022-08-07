using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolSupport.Base;

namespace ToolSupport
{
  public partial class MainForm : Form
  {
    public static SupportToolHttpClient client;

    public static string token;
    public MainForm()
    {
      InitializeComponent();
    }

    private void btnLoginClick(object sender, EventArgs e)
    {
      this.Login();
    }
    private void btnGetProjectClick(object sender, EventArgs e)
    {
      this.GetProject();
    }

    private void btnGetTaskClick(object sender, EventArgs e)
    {
      this.GetTask();
    }

    private void btnGetMemberClick(object sender, EventArgs e)
    {
      this.GetMember();
    }

    private void btnGetProjectMemberClick(object sender, EventArgs e)
    {
      this.GetProjectMember();
    }
  }
}
