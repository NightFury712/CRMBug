using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Entities;

namespace ToolSupport.Base
{
  public class SupportToolHttpClient
  {
    private static HttpClient client;
    public SupportToolHttpClient(string token, bool isAnonymous = false)
    {
      GenerateSupportToolHttpClient(token, isAnonymous);
    }

    public string GetBaseURL()
    {
      var url = "https://localhost:44378/api/v1/";
      return url;
    }

    public void GenerateSupportToolHttpClient(string token = "", bool isAnonymous = false)
    {
      HttpClientHandler clientHandler = new HttpClientHandler();
      clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
      client = new HttpClient(clientHandler);
      client.BaseAddress = new Uri(GetBaseURL());
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      if(!isAnonymous)
      {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      }
      
    }

    public ServiceResult Get(string path)
    {
      ServiceResult rs = new ServiceResult();
      var response = client.GetAsync(path).GetAwaiter().GetResult();
      var result = response.Content.ReadAsStringAsync();
      if(response.IsSuccessStatusCode)
      {
        rs = Utils.Deserialize<ServiceResult>(Convert.ToString(result.Result));
      } else
      {
        rs.Data = response.StatusCode;
      }
      return rs;
    }

    public ServiceResult Post(string path, object param = null)
    {
      ServiceResult rs = new ServiceResult();
      var response = client.PostAsync(path, new StringContent(Utils.Serialize(param), Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
      var result = response.Content.ReadAsStringAsync();
      if (response.IsSuccessStatusCode)
      {
        rs = Utils.Deserialize<ServiceResult>(Convert.ToString(result.Result));
      } else
      {
        rs.Data = response.StatusCode;
      }
      return rs;
    }
  }
}
