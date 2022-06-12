using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Constant
{
  public class Constant
  {
    public const string DLIssue_GetFormData = "SELECT dtt.* FROM issue_dictionary_data dtt JOIN issue_dictionary dt ON dt.ID = dtt.DictionaryID WHERE dt.FieldName = 'Type';SELECT dtt.* FROM issue_dictionary_data dtt JOIN issue_dictionary dt ON dt.ID = dtt.DictionaryID WHERE dt.FieldName = 'Priority';SELECT dtt.* FROM issue_dictionary_data dtt JOIN issue_dictionary dt ON dt.ID = dtt.DictionaryID WHERE dt.FieldName = 'State';";
  }
}
