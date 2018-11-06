using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interakční logika pro Hra.xaml
    /// </summary>
    public partial class Hra : Page
    {
        private Frame frame;
        Random RNG = new Random();
        private int cislootazky = 1;
        private Button spravnaodpoved;
        private DispatcherTimer DTimer = new DispatcherTimer();
        public Hra()
        {
            InitializeComponent();
        }
        public Hra(Frame frame) : this()
        {
            this.frame = frame;
            NacistOtazku(cislootazky);
        }
        public void NacistOtazku(int cislootazky)
        {
            FileInfo soubor = new FileInfo("Otazky.xlsx");
            using (ExcelPackage package = new ExcelPackage(soubor))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                OtazkaZadani.Text = string.Concat(worksheet.Cells[cislootazky, 1].Value);
                int RandomCislo = RNG.Next(0, 4);
                int CisloOdpovedi = 3;
                List<Button> Odpovedi = new List<Button>();
                Odpovedi.Add(Odpoved1);
                Odpovedi.Add(Odpoved2);
                Odpovedi.Add(Odpoved3);
                Odpovedi.Add(Odpoved4);
                for (int i = 0; i < 4; i++)
                {
                    if (i == RandomCislo)
                    {
                        Odpovedi[i].Content = string.Concat(worksheet.Cells[cislootazky, 2].Value);
                        spravnaodpoved = Odpovedi[i];
                    } else
                    {
                        Odpovedi[i].Content = string.Concat(worksheet.Cells[cislootazky, CisloOdpovedi].Value);
                        CisloOdpovedi++;
                    }
                }
            }
            Buttons_IsEnabled(true);
        }
        private void OdpovedKlik(object sender, RoutedEventArgs e)
        {
            Button batn = (Button)sender;
            Buttons_IsEnabled(false);
            if (sender == spravnaodpoved)
            {
                OtazkaZadani.Text = "spravne";
            }
            else
            {
                OtazkaZadani.Text = "spatne";
                batn.Background = Brushes.Red;
                batn.BorderBrush = Brushes.Red;
            }
            cislootazky++;
            spravnaodpoved.Background = Brushes.LimeGreen;
            spravnaodpoved.BorderBrush = Brushes.LimeGreen;
            DTimer.Interval = TimeSpan.FromMilliseconds(3000);
            DTimer.Tick += (s, args) => TimerNacteniOtazky();
            DTimer.Start();
        }
        private void TimerNacteniOtazky()
        {
            spravnaodpoved.Background = (Brush)new BrushConverter().ConvertFrom("#FF673AB7");
            spravnaodpoved.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF673AB7");
            NacistOtazku(cislootazky);
            DTimer.Stop();
        }
        private void Buttons_IsEnabled(bool enabled)
        {
            Odpoved1.IsEnabled = enabled;
            Odpoved2.IsEnabled = enabled;
            Odpoved3.IsEnabled = enabled;
            Odpoved4.IsEnabled = enabled;
        }
    }
}
