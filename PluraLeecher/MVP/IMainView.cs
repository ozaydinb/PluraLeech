using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluraLeecher.MVP
{
    public interface IMainView
    {
        WebBrowser WebBrowser { get; }
        List<string> RequestList { get; }
        void AddRequest(string requestAddress);
        void ClearVideoTitleList();
        void AddVideoTitle(Video video);
        
    }
}
