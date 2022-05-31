using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Library
{
  public class SessionData
  {
    public static long ID
    {
      get
      {
        return SessionData.Get<long>("ID");
      }
    }
    public static string FullName
    { get
      {
        return SessionData.Get<string>("FullName");
      }
    }

    public static string Email
    {
      get
      {
        return SessionData.Get<string>("Email");
      }
    }

    public static void Set(string key, object value)
    {
      HttpContext.Current.Session[key] = value;
    }

    public static void Remove(string key)
    {
      HttpContext.Current.Session.Remove(key);
    }

    public static T Get<T>(string key)
    {
      return (T)HttpContext.Current.Session[key];
    }

    public static void Clear()
    {
      HttpContext.Current.Session.Clear();
    }
  }
}
