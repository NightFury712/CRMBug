using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolSupport
{
  public partial class MainForm : Form
  {
    static DataTable ToDataTable(List<Dictionary<string, object>> list)
    {
      DataTable result = new DataTable();
      if (list.Count == 0)
        return result;

      var columnNames = list.SelectMany(dict => dict.Keys).Distinct();
      result.Columns.AddRange(columnNames.Select(c => new DataColumn(c)).ToArray());
      foreach (Dictionary<string, object> item in list)
      {
        var row = result.NewRow();
        foreach (var key in item.Keys)
        {
          row[key] = item[key];
        }

        result.Rows.Add(row);
      }

      return result;
    }

    public void ShowData(DataGridView dataGridView, List<Dictionary<string, object>> list)
    {
      var dataTable = ToDataTable(list);
      dataGridView.DataSource = dataTable;
      dataGridView.Visible = true;
    }
  }
}
