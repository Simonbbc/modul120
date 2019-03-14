using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class APIDemo
    {
        #region Userstory
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // Userstory
            Data.Userstory userstory = new Data.Userstory();
            userstory.Title = "Artikel 1";
            userstory.Text = "Something";
            userstory.CreatedAt = DateTime.Today;
            Int64 userstoryId = userstory.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + userstoryId);
        }
        public static void DemoACreateKurz()
        {
            Data.Userstory userstory2 = new Data.Userstory { Title = "Artikel 2", CreatedAt = DateTime.Today, Text = "Something2" };
            Int64 userstory2Id = userstory2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + userstory2Id);
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Userstory userstory in Data.Userstory.LesenAlle())
            {
                Debug.Print("Artikel Id:" + userstory.UserstoryId + " Name:" + userstory.Title);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // Userstory ändert Attribute
            Data.Userstory userstory = Data.Userstory.LesenFirst();
            userstory.Title = "Artikel 1 nach Update";
            userstory.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.Userstory.LesenFirst().Loeschen();
            Debug.Print("Artikel mit Id 1 gelöscht");
        }
        #endregion
    }
}
