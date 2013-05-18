using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PluraLeecher.Models;

namespace PluraLeecher.MVP
{
    public interface IMainView
    {
        WebBrowser WebBrowser { get; }
        BindingList<Video> VideoTitleList { get; set; }

        void ShowMessage(string toString);
    }
}
