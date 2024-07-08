using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Abstraction
{
    public interface IWinformsHost : IHost
    {
        void Run(Type mainFormType);
    }
}