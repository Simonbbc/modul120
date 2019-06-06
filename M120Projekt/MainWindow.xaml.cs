using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using M120Projekt.B1;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Window1 _overview;
        private CreateOverview _createOverview;

        public MainWindow()
        {
            _overview = new Window1();
            _createOverview = new CreateOverview();
            _overview.CreateClicked += CreateClicked;
            _createOverview.Back += BackClicked;
            InitializeComponent();
            Content.Children.Add(_overview);
        }

        public void CreateClicked(object sender, EventArgs e)
        {
            Content.Children.Clear();
            Content.Children.Add(_createOverview);
        }

        public void BackClicked(object sender, EventArgs e)
        {
            _overview.UpdateList();
            Content.Children.Clear();
            Content.Children.Add(_overview);
        }
    }
}
