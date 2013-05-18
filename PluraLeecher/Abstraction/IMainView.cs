using System.ComponentModel;
using System.Windows.Forms;
using PluraLeecher.Models;

namespace PluraLeecher.Abstraction
{
    public interface IMainView
    {
        WebBrowser WebBrowser { get; }
        BindingList<Video> VideoTitleList { get; set; }

        void ShowMessage(string toString);
    }
}
