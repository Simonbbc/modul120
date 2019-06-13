using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace M120Projekt.B1
{
    /// <summary>
    /// Interaktionslogik für updateView.xaml
    /// </summary>
    public partial class updateView : UserControl
    {
        public event EventHandler Back;
        long id;
        public updateView()
        {
            InitializeComponent();
            

        }

        public void ShowItem(long id)
        {
            this.id = id;
            Data.Userstory loadDB = Data.Userstory.LesenID(id);
            Title.Text = loadDB.Title;
            Story.Text = loadDB.Text;
            DOD.Text = loadDB.DefinitionOfDone;
            phasenBox.Text = loadDB.Phase;
            Date.SelectedDate = loadDB.CreatedAt;
            Show.IsChecked = loadDB.ShowInBacklog;
            StoryPoints.Text = Convert.ToString(loadDB.StoryPoints);
        }

        private bool Check()
        {
            if (this.Title.Text == "")
            {
                MessageBox.Show("Please fill out the Title Field");
                return false;
            }
            if (String.IsNullOrEmpty(this.Story.Text))
            {
                MessageBox.Show("Please fill out the Story Field");
                return false;
            }
            if (String.IsNullOrEmpty(this.DOD.Text))
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
        //Safe Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Check()) {
                Data.Userstory us = Data.Userstory.LesenID(id);
                us.Title = Title.Text;
                us.Text = Story.Text;
                us.DefinitionOfDone = DOD.Text;
                us.Phase = phasenBox.Text;
                us.CreatedAt = Date.SelectedDate ?? DateTime.Today;
                us.ShowInBacklog = Show.IsChecked ?? false;
                us.StoryPoints = Convert.ToInt32(StoryPoints.Text);
                us.Aktualisieren();

                Back.Invoke(this, EventArgs.Empty);
            }
        }
        //Delete Button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Data.Userstory.LesenID(id).Loeschen();
            Back.Invoke(this, EventArgs.Empty);
        }
        //Abbrechen Button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Back.Invoke(this, EventArgs.Empty);
        }
    }
}
