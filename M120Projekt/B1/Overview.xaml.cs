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
        private ObservableCollection<Userstory> userStoryList = new ObservableCollection<Userstory>();

        public Window1()
        {
            InitializeComponent();
            liste.ItemsSource = userStoryList;
            UpdateList();
            buttonCreate_Copy.Click += BtnSave;
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
    }
}
