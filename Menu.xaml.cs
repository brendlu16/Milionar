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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Milionar
{
    /// <summary>
    /// Interakční logika pro Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private Frame frame;
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(Frame frame) : this()
        {
            this.frame = frame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Hra(frame));
        }
    }
}
