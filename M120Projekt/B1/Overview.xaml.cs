using M120Projekt.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace M120Projekt.B1
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : UserControl
    {
        public event EventHandler CreateClicked;
        public event EventHandler ItemClicked;
        private ObservableCollection<Userstory> userStoryList;

        public Window1()
        {
            InitializeComponent();
            userStoryList = new ObservableCollection<Userstory>();
            auswahlListe.ItemsSource = userStoryList;
            UpdateList();
        }

        public void UpdateList() {
            userStoryList.Clear();
            foreach (var s in Userstory.LesenAlle())
            {
                userStoryList.Add(s);
            }
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateClicked?.Invoke(sender, e);
        }

        private void BtnSave(object o, RoutedEventArgs e) => Global.Context.SaveChanges();

        private void Liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            auswahlgeaendert();
        }

        private void Liste_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (auswahlListe.SelectedItem != null)
            {
                Userstory auswahl = (Userstory)auswahlListe.SelectedItem;
                ItemClicked.Invoke(auswahl.UserstoryId, EventArgs.Empty);
            }
        }

        private void datenVorbereiten()
        {
            userStoryList = new ObservableCollection<Userstory>(Userstory.LesenAlle());
        }
        private void auswahlgeaendert()
        {
            if (auswahlListe.SelectedItem != null)
            {
                Userstory auswahl = (Userstory)auswahlListe.SelectedItem;
            }
        }
    }
}
