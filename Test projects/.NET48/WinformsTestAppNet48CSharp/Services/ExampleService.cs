using System.Windows.Forms;

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
            MessageBox.Show("Do Something");
        }
    }
}
