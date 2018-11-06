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
using System.Windows.Threading;

namespace Milionar
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Frame1.Navigate(new Menu(Frame1));

            /*DispatcherTimer DTimer = new DispatcherTimer();
            DTimer.Interval = TimeSpan.FromMilliseconds(300);
            DTimer.Tick += (s, args) => Timer_Tick();
            DTimer.Start();*/
        }
        /*int i = 0;
        void Timer_Tick()
        {
            i += 1;
        }*/
    }
}
