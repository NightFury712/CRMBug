using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Library
{
  public class SessionData
  {
    private static IHttpContextAccessor _httpContextAccessor;
    private static HttpContext httpContext => HttpContextAccessor.HttpContext;
    public static IHttpContextAccessor HttpContextAccessor
    {
      get
      {
        if (_httpContextAccessor == null)
        {
          _httpContextAccessor = new HttpContextAccessor();
          return _httpContextAccessor;
        }
        else
        {
          return _httpContextAccessor;
        }
      }
    }
    public static string UserID
    {
      get
      {
        return httpContext.User.FindFirst("ID")?.Value;
      }
    }
    public static string FullName
    {
      get
      {
        return httpContext.User.FindFirst("FullName")?.Value;
      }
    }
    public static string Email
    {
      get
      {
        return httpContext.User.FindFirst("Email")?.Value;
      }
    }
  }
}
