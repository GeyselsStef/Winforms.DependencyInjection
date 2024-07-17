using DDDSoft.Windows.Winforms.Extensions;
using DDDSoft.Windows.Winforms.Navigation;
using WinFormsTestAppNet6CSharp.Forms;

namespace WinFormsTestAppNet6CSharp
{
    public partial class Form1 : Form
    {
        private readonly IFormNavigator _formNavigator;

        public Form1(IFormNavigator formNavigator)
        {
            _formNavigator = formNavigator;

            InitializeComponent();
        }

        private void ButtonOpenTestForm1_Click(object sender, System.EventArgs e)
        {
            _formNavigator.ShowForm<TestForm>();
        }

        private void ButtonOpenTestForm2_Click(object sender, System.EventArgs e)
        {
            DialogResult result = _formNavigator.ShowDialog<DialogForm>();
        }
    }
}
