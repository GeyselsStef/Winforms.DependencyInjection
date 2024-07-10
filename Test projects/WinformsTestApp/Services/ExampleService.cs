using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsTestApp.Services
{
    public interface IExampleService
    {
        void DoSomething();
    }

    public class ExampleService : IExampleService
    {
        public void DoSomething()
        {
            // Do something
        }
    }
}
