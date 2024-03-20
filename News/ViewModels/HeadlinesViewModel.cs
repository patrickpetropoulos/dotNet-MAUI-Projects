using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using News.Models;
using News.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace News.ViewModels;
public partial class HeadlinesViewModel : ViewModel
{
  private readonly INewsService newsService;

  [ObservableProperty]
  private NewsResult currentNews;

  public HeadlinesViewModel( INewsService newsService )
  {
    this.newsService = newsService;
  }
  public async Task Initialize(string scope) =>
    await Initialize(scope.ToLower() switch
    {
      "headlines" => NewsScope.Headlines,
      "local" => NewsScope.Local,
      "global" => NewsScope.Global,
      _ => throw new NotImplementedException( "Invalid NewsScope" ),
    });

  public async Task Initialize( NewsScope scope )
  {
    CurrentNews = await newsService.GetNews( scope );
  }
  [RelayCommand]
  public void ItemSelected(object selectedItem)
  {
    var selectedArticle = selectedItem as Article;
    var url = HttpUtility.UrlEncode(selectedArticle.Url);
  } 

}
