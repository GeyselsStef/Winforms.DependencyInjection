using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformsTestApp.Services;

namespace WinformsTestApp.Forms
{
    public partial class TestForm : Form
    {
        private readonly IExampleService _exampleService;

        public TestForm(IExampleService exampleService)
        {
            _exampleService = exampleService;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _exampleService.DoSomething();
        }
    }
}
