using News.Models;
using News.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace News.Services;
public class NewsService : INewsService, IDisposable
{
  private bool disposedValue;
  const string UriBase = "https://newsapi.org/v2";
  readonly HttpClient httpClient = new()
  {
    BaseAddress = new Uri( UriBase ),
    DefaultRequestHeaders =
    {
      { "user-agent","maui-projects-news/1.0" }
    }
  };
  public async Task<NewsResult> GetNews( NewsScope scope )
  {
    NewsResult result;
    string url = GetUrl(scope );
    try
    {
      result = await httpClient.GetFromJsonAsync<NewsResult>( url );
    }
    catch( Exception ex )
    {
      result = new()
      {
        Articles = new()
        {
          new(){
            Title = $"HTTP Get failed: {ex.Message}, PublishedAt = {DateTime.Now}" },
          }
      };
     
    }
    return result;
  }

  private string GetUrl( NewsScope scope ) => scope switch
  {
    NewsScope.Headlines => Headlines,
    NewsScope.Local => Local,
    NewsScope.Global => Global,
    _ => throw new NotImplementedException( "Invalid NewsScope" ),
  };

  private static string Headlines => $"{UriBase}/top-headlines?country=us&apiKey={Settings.NewsApiKey}";
  private static string Local => $"{UriBase}/everything?q=local&apiKey={Settings.NewsApiKey}";
  private static string Global => $"{UriBase}/everything?q=global&apiKey={Settings.NewsApiKey}";
  protected virtual void Dispose( bool disposing ) 
  {
    if(!disposedValue)
    {
      if(disposing){
        httpClient.Dispose();
      }
      disposedValue = true;
    }
  }
  
  public void Dispose()
  {
    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    Dispose(disposing: true);
    GC.SuppressFinalize(this);
  }

}
