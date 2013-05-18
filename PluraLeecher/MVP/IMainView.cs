using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluraLeecher.MVP
{
    public interface IMainView
    {
        WebBrowser WebBrowser { get; }
        BindingList<Video> VideoTitleList { get; set; }
        
    }
}
