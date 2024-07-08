using DDDSoft.Windows.Winforms.Abstraction;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Extensions
{
    public static class WinformsHostExtensions
    {
        public static void Run<TForm>(this IWinformsHost winformsHost) where TForm : Form
        {
            winformsHost.Run(typeof(TForm));
        }

    }
}
