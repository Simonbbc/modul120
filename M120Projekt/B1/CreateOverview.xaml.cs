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
using M120Projekt.Data;


namespace M120Projekt.B1
{

    /// <summary>
    /// Interaktionslogik für CreateOverview.xaml
    /// </summary>
    public partial class CreateOverview : UserControl
    {
        private Userstory us = new Userstory();

        public CreateOverview()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Data.Global.context = new Data.Context();
            if(this.Check())
            {
                this.FülleFelder();
                us.Erstellen();
                MessageBox.Show("Success");
            } else
            {
                MessageBox.Show("Please fill out all felds");
            }
            
        }

        private void FülleFelder()
        {
            us.Title = this.Title.Text;
            us.Text = this.Story.Text;
            us.DefinitionOfDone = this.DOD.Text;
            us.Phase = this.phasenBox.SelectedValue.ToString();
            us.CreatedAt = DateTime.Today;
        }

        private bool Check()
        {
            if (this.Title.Text == "")
            {
                return false;
            }
            if(this.Story.Text == "")
            {
                return false;
            }
            if(this.DOD.Text == "")
            {
                return false;
            }
            if(this.StoryPoints.Text == "")
            {
                return false;
            }
            return true;
        }
            
    }
}
