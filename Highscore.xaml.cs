using Newtonsoft.Json;
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

namespace Milionar
{
    /// <summary>
    /// Interakční logika pro Highscore.xaml
    /// </summary>
    public partial class Highscore : Page
    {
        private Frame frame;
        public Highscore()
        {
            InitializeComponent();
        }
        public Highscore(Frame frame) : this()
        {
            this.frame = frame;
            NacistHS();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Menu(frame));
        }
        private void NacistHS()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string jsonFromFile = File.ReadAllText("highscores.json");
            List<Skore> skores = JsonConvert.DeserializeObject<List<Skore>>(jsonFromFile, settings);
            for (int i = 0; i < skores.Count; i++)
            {
                Label LabelHS = (Label)this.FindName("LabelHS" + (i + 1));
                LabelHS.Content = skores[i].Name + " - " + skores[i].Vyhra;
            }
        }
    }
}
