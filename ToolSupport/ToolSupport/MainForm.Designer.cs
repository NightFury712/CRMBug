
namespace ToolSupport
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tpProject = new System.Windows.Forms.TabPage();
            this.lblNotifyProject = new System.Windows.Forms.Label();
            this.dgvProject = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearchProject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.tpTask = new System.Windows.Forms.TabPage();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.lblNotifyTask = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tpMember = new System.Windows.Forms.TabPage();
            this.dgvMember = new System.Windows.Forms.DataGridView();
            this.lblNotifyMember = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tpProjectMember = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSearchProjecrMember = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetDataPM = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRemoveMember = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tpProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).BeginInit();
            this.panel2.SuspendLayout();
            this.tpTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.panel3.SuspendLayout();
            this.tpMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            this.panel1.SuspendLayout();
            this.tpProjectMember.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tpProject);
            this.tabControlMain.Controls.Add(this.tpTask);
            this.tabControlMain.Controls.Add(this.tpMember);
            this.tabControlMain.Controls.Add(this.tpProjectMember);
            this.tabControlMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControlMain.ItemSize = new System.Drawing.Size(90, 40);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1350, 729);
            this.tabControlMain.TabIndex = 0;
            // 
            // tpProject
            // 
            this.tpProject.Controls.Add(this.lblNotifyProject);
            this.tpProject.Controls.Add(this.dgvProject);
            this.tpProject.Controls.Add(this.panel2);
            this.tpProject.Location = new System.Drawing.Point(4, 44);
            this.tpProject.Name = "tpProject";
            this.tpProject.Padding = new System.Windows.Forms.Padding(3);
            this.tpProject.Size = new System.Drawing.Size(1342, 681);
            this.tpProject.TabIndex = 0;
            this.tpProject.Text = "Project";
            this.tpProject.UseVisualStyleBackColor = true;
            // 
            // lblNotifyProject
            // 
            this.lblNotifyProject.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblNotifyProject.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNotifyProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNotifyProject.Location = new System.Drawing.Point(3, 166);
            this.lblNotifyProject.Name = "lblNotifyProject";
            this.lblNotifyProject.Size = new System.Drawing.Size(1336, 30);
            this.lblNotifyProject.TabIndex = 2;
            this.lblNotifyProject.Text = "Lấy dữ liệu thành công!";
            this.lblNotifyProject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvProject
            // 
            this.dgvProject.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProject.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProject.Location = new System.Drawing.Point(3, 166);
            this.dgvProject.Name = "dgvProject";
            this.dgvProject.RowTemplate.Height = 25;
            this.dgvProject.Size = new System.Drawing.Size(1336, 512);
            this.dgvProject.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.txtSearchProject);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnGetData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1336, 163);
            this.panel2.TabIndex = 0;
            // 
            // txtSearchProject
            // 
            this.txtSearchProject.Location = new System.Drawing.Point(95, 17);
            this.txtSearchProject.Name = "txtSearchProject";
            this.txtSearchProject.PlaceholderText = "Tìm kiếm theo tên, mã dự án";
            this.txtSearchProject.Size = new System.Drawing.Size(200, 27);
            this.txtSearchProject.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm";
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGetData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGetData.Location = new System.Drawing.Point(317, 14);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(144, 32);
            this.btnGetData.TabIndex = 0;
            this.btnGetData.Text = "Lấy dữ liệu";
            this.btnGetData.UseVisualStyleBackColor = false;
            // 
            // tpTask
            // 
            this.tpTask.Controls.Add(this.dgvTask);
            this.tpTask.Controls.Add(this.lblNotifyTask);
            this.tpTask.Controls.Add(this.panel3);
            this.tpTask.Location = new System.Drawing.Point(4, 44);
            this.tpTask.Name = "tpTask";
            this.tpTask.Padding = new System.Windows.Forms.Padding(3);
            this.tpTask.Size = new System.Drawing.Size(1342, 681);
            this.tpTask.TabIndex = 1;
            this.tpTask.Text = "Task";
            this.tpTask.UseVisualStyleBackColor = true;
            // 
            // dgvTask
            // 
            this.dgvTask.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTask.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTask.Location = new System.Drawing.Point(3, 196);
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.RowTemplate.Height = 25;
            this.dgvTask.Size = new System.Drawing.Size(1336, 482);
            this.dgvTask.TabIndex = 2;
            // 
            // lblNotifyTask
            // 
            this.lblNotifyTask.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblNotifyTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNotifyTask.Location = new System.Drawing.Point(3, 166);
            this.lblNotifyTask.Name = "lblNotifyTask";
            this.lblNotifyTask.Size = new System.Drawing.Size(1336, 30);
            this.lblNotifyTask.TabIndex = 1;
            this.lblNotifyTask.Text = "Thông báo";
            this.lblNotifyTask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1336, 163);
            this.panel3.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Tìm kiếm theo tên, mã, người thực hiện công việc";
            this.textBox1.Size = new System.Drawing.Size(250, 27);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tìm kiếm";
            // 
            // tpMember
            // 
            this.tpMember.Controls.Add(this.dgvMember);
            this.tpMember.Controls.Add(this.lblNotifyMember);
            this.tpMember.Controls.Add(this.panel1);
            this.tpMember.Location = new System.Drawing.Point(4, 44);
            this.tpMember.Name = "tpMember";
            this.tpMember.Padding = new System.Windows.Forms.Padding(3);
            this.tpMember.Size = new System.Drawing.Size(1342, 681);
            this.tpMember.TabIndex = 1;
            this.tpMember.Text = "Member";
            this.tpMember.UseVisualStyleBackColor = true;
            // 
            // dgvMember
            // 
            this.dgvMember.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMember.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMember.Location = new System.Drawing.Point(3, 196);
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.RowTemplate.Height = 25;
            this.dgvMember.Size = new System.Drawing.Size(1336, 482);
            this.dgvMember.TabIndex = 3;
            // 
            // lblNotifyMember
            // 
            this.lblNotifyMember.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblNotifyMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNotifyMember.Location = new System.Drawing.Point(3, 166);
            this.lblNotifyMember.Name = "lblNotifyMember";
            this.lblNotifyMember.Size = new System.Drawing.Size(1336, 30);
            this.lblNotifyMember.TabIndex = 2;
            this.lblNotifyMember.Text = "Thông báo";
            this.lblNotifyMember.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 163);
            this.panel1.TabIndex = 0;
            // 
            // tpProjectMember
            // 
            this.tpProjectMember.Controls.Add(this.dataGridView1);
            this.tpProjectMember.Controls.Add(this.label4);
            this.tpProjectMember.Controls.Add(this.panel4);
            this.tpProjectMember.Location = new System.Drawing.Point(4, 44);
            this.tpProjectMember.Name = "tpProjectMember";
            this.tpProjectMember.Padding = new System.Windows.Forms.Padding(3);
            this.tpProjectMember.Size = new System.Drawing.Size(1342, 681);
            this.tpProjectMember.TabIndex = 0;
            this.tpProjectMember.Text = "Project Member";
            this.tpProjectMember.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.btnRemoveMember);
            this.panel4.Controls.Add(this.txtSearchProjecrMember);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnGetDataPM);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1336, 163);
            this.panel4.TabIndex = 1;
            // 
            // txtSearchProjecrMember
            // 
            this.txtSearchProjecrMember.Location = new System.Drawing.Point(95, 17);
            this.txtSearchProjecrMember.Name = "txtSearchProjecrMember";
            this.txtSearchProjecrMember.PlaceholderText = "Tìm kiếm theo tên, mã dự án";
            this.txtSearchProjecrMember.Size = new System.Drawing.Size(200, 27);
            this.txtSearchProjecrMember.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tìm kiếm";
            // 
            // btnGetDataPM
            // 
            this.btnGetDataPM.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGetDataPM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGetDataPM.Location = new System.Drawing.Point(317, 14);
            this.btnGetDataPM.Name = "btnGetDataPM";
            this.btnGetDataPM.Size = new System.Drawing.Size(144, 32);
            this.btnGetDataPM.TabIndex = 0;
            this.btnGetDataPM.Text = "Lấy dữ liệu";
            this.btnGetDataPM.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1336, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thông báo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.Location = new System.Drawing.Point(3, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1336, 482);
            this.dataGridView1.TabIndex = 4;
            // 
            // btnRemoveMember
            // 
            this.btnRemoveMember.BackColor = System.Drawing.Color.Red;
            this.btnRemoveMember.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveMember.Location = new System.Drawing.Point(482, 14);
            this.btnRemoveMember.Name = "btnRemoveMember";
            this.btnRemoveMember.Size = new System.Drawing.Size(127, 32);
            this.btnRemoveMember.TabIndex = 3;
            this.btnRemoveMember.Text = "Xóa nhân viên";
            this.btnRemoveMember.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tìm kiếm";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(81, 17);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Tìm kiếm theo tên, tên nhân viên";
            this.textBox2.Size = new System.Drawing.Size(208, 27);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(307, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Lấy dữ liệu";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(367, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "Lấy dữ liệu";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControlMain.ResumeLayout(false);
            this.tpProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tpTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tpMember.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpProjectMember.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControlMain;
    private System.Windows.Forms.TabPage tpProject;
    private System.Windows.Forms.TabPage tpTask;
    private System.Windows.Forms.TabPage tpMember;
    private System.Windows.Forms.TabPage tpProjectMember;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btnGetData;
    private System.Windows.Forms.TextBox txtSearchProject;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView dgvProject;
    private System.Windows.Forms.Label lblNotifyProject;
    private System.Windows.Forms.Label lblNotifyTask;
    private System.Windows.Forms.DataGridView dgvTask;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label lblNotifyMember;
    private System.Windows.Forms.DataGridView dgvMember;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.TextBox txtSearchProjecrMember;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnGetDataPM;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnRemoveMember;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
  }
}
