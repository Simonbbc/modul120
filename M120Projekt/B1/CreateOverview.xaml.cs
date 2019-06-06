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
using System.Text.RegularExpressions;


namespace M120Projekt.B1
{

    /// <summary>
    /// Interaktionslogik für CreateOverview.xaml
    /// </summary>
    public partial class CreateOverview : UserControl
    {
        private Userstory us = new Userstory();

        public event EventHandler Back;

        public CreateOverview()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.Check())
            {
                this.FülleFelder();
                us.Erstellen();
                MessageBox.Show("Success");
                Global.Context.SaveChanges();
                Back.Invoke(this, EventArgs.Empty);
            } 
            
        }

        private void FülleFelder()
        {
            us.Title = this.Title.Text;
            us.Text = this.Story.Text;
            us.DefinitionOfDone = this.DOD.Text;
            us.Phase = this.phasenBox.SelectedValue.ToString();
            us.CreatedAt = Date.SelectedDate ?? DateTime.Today;
            us.ShowInBacklog = Show.IsChecked ?? false;
            us.StoryPoints = Convert.ToInt32(StoryPoints.Text);
        }

        private bool Check()
        {
            if (this.Title.Text == "")
            {
                MessageBox.Show("Please fill out the Title Field");
                return false;
            }
            if(String.IsNullOrEmpty(this.Story.Text))
            {
                MessageBox.Show("Please fill out the Story Field");
                return false;
            }
            if(String.IsNullOrEmpty(this.DOD.Text))
            {
                MessageBox.Show("Please fill out the Definition of Done Field");
                return false;
            }
            if (String.IsNullOrEmpty(this.StoryPoints.Text) || !Regex.IsMatch(this.StoryPoints.Text, @"^[0-9]*$"))
            {
                MessageBox.Show("Please enter a valid number (0-100)");
                return false;
            }
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Back.Invoke(sender, EventArgs.Empty);
        }
    }
}
