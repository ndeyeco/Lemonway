using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using FibonacciWindowForm.FibonacciService;

namespace FibonacciWindowForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var service = new Fibonacci();
            var loader = new LoaderForm();
            loader.Show();
            long result = 0;
            Task.Factory.StartNew(() =>
            {
                result = service.FibonacciItterative(10);
            })
            .ContinueWith(t =>
            {
                loader.Close();
                MessageBox.Show(result.ToString());
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}