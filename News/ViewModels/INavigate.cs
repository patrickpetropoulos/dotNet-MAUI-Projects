using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.ViewModels
{
    public interface INavigate
    {
      Task NavigateTo(string url);
    Task PushModal( Page page );
    Task PopModal();
    }
}
