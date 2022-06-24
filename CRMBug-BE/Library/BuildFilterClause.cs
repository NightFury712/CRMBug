using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using static Library.Enumeration.Enumeration;

namespace Library
{
  public static class BuildFilterClause
  {
    public static string BuildFilter(ParamGrid param)
    {
      StringBuilder oWhere = new StringBuilder("( (1=1)");
      var filters = param.Filters.Where(x => x.IsFormula == false)?.ToList();
      var formulas = param.Filters.Where(x => x.IsFormula == true)?.ToList();
      if (filters != null && filters.Any())
      {
        foreach(var fieldFilter in filters)
        {
          string tmpQuery = string.Empty;
          switch(fieldFilter.Addition)
          {
            case Addition.And:
              tmpQuery += " AND";
              break;
            case Addition.Or:
              tmpQuery += " OR";
              break;
          }
          switch(fieldFilter.Operator)
          {
            case Operator.Equal:
              tmpQuery = $"{tmpQuery} {fieldFilter.FieldName} = '{fieldFilter.Value}' ";
              break;
            case Operator.Like:
              tmpQuery = $"{tmpQuery} {fieldFilter.FieldName} LIKE N'%{fieldFilter.Value}%' ";
              break;
          }
          oWhere.Append(tmpQuery);
        }
      }
      if(!string.IsNullOrEmpty(param.Formula) && formulas != null && formulas.Any())
      {
        List<string> formulaQuery = new List<string>();
        foreach (var fieldFilter in formulas)
        {
          string tmpQuery = string.Empty;
          switch (fieldFilter.Operator)
          {
            case Operator.Equal:
              tmpQuery = $"{fieldFilter.FieldName} = '{fieldFilter.Value}' ";
              break;
            case Operator.Like:
              tmpQuery = $"{fieldFilter.FieldName} LIKE N'%{fieldFilter.Value}%' ";
              break;
          }
          formulaQuery.Add(tmpQuery);
        }
        oWhere.Append($" AND {string.Format(param.Formula, formulaQuery.ToArray())}");
      }
      oWhere.Append($")");
      return oWhere.ToString();
    }
  }
}
