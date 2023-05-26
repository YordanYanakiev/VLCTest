using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VLCTest
{
    /// <summary>
    /// Interaction logic for Example1.xaml
    /// </summary>
    public partial class Example1 : Window
    {
        readonly Controls _controls;

        public Example1()
        {
            InitializeComponent();

            _controls = new Controls(this);
            VideoView.Content = _controls;
        }

        protected override void OnClosed(EventArgs e)
        {
            VideoView.Dispose();
        }
    }
}
