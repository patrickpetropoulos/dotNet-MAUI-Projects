using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.ViewModels;
[ObservableObject]
public abstract partial class ViewModel
{
  public INavigate Navigator { get; init; }
  internal ViewModel (INavigate navigator ) => Navigator = navigator;
}
