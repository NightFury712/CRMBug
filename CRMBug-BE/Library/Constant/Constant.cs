using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Constant
{
  public class Constant
  {
    public const string DLBase_GetFormData = "SELECT dtt.* FROM {0}_dictionary_data dtt JOIN {0}_dictionary dt ON dt.ID = dtt.DictionaryID WHERE dt.FieldName = 'Type';SELECT dtt.* FROM {0}_dictionary_data dtt JOIN {0}_dictionary dt ON dt.ID = dtt.DictionaryID WHERE dt.FieldName = 'Priority';SELECT dtt.* FROM {0}_dictionary_data dtt JOIN {0}_dictionary dt ON dt.ID = dtt.DictionaryID WHERE dt.FieldName = 'State';";
  }
}
