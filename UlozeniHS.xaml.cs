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
    /// Interakční logika pro UlozeniHS.xaml
    /// </summary>
    public partial class UlozeniHS : Page
    {
        static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
        static string jsonFromFile = File.ReadAllText("highscores.json");
        List<Skore> skores = JsonConvert.DeserializeObject<List<Skore>>(jsonFromFile, settings);
        private Frame frame;
        private Skore NewScore;
        public UlozeniHS()
        {
            InitializeComponent();
        }
        public UlozeniHS(Frame frame, int cislootazky) : this()
        {
            this.frame = frame;
            List<string> vyhry = new List<string>();
            vyhry.Add("1 000");
            vyhry.Add("2 000");
            vyhry.Add("3 000");
            vyhry.Add("5 000");
            vyhry.Add("10 000");
            vyhry.Add("20 000");
            vyhry.Add("40 000");
            vyhry.Add("80 000");
            vyhry.Add("160 000");
            vyhry.Add("320 000");
            vyhry.Add("640 000");
            vyhry.Add("1 250 000");
            vyhry.Add("2 500 000");
            vyhry.Add("5 000 000");
            vyhry.Add("10 000 000");
            this.NewScore = new Skore() { Name = "", Vyhra = vyhry[cislootazky - 1], uroven = cislootazky };
        }

        private void UlozitHSButton_Click(object sender, RoutedEventArgs e)
        {
            NewScore.Name = InputName.Text;
            for (int i = 0; i < skores.Count; i++)
            {
                if (skores[i].uroven < NewScore.uroven)
                {
                    Skore temp = skores[i];
                    skores[i] = NewScore;
                    NewScore = temp;
                }
            }
            if (skores.Count < 10)
            {
                skores.Add(NewScore);
            }
            string json = JsonConvert.SerializeObject(skores, settings);
            File.WriteAllText("highscores.json", json);
            frame.Navigate(new Menu(frame));
        }

        private void NeulozitHSButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Menu(frame));
        }
    }
}
