﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Userstory
    {
        #region Datenbankschicht
        [Key]
        public Int64 UserstoryId { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Text { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        #endregion
        #region Applikationsschicht
        public Userstory() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static IEnumerable<Data.Userstory> LesenAlle()
        {
            return (from record in Data.Global.context.Userstory select record);
        }
        public static Data.Userstory LesenID(Int64 userstoryId)
        {
            return (from record in Data.Global.context.Userstory where record.UserstoryId == userstoryId select record).FirstOrDefault();
        }
        public static Data.Userstory LesenFirst()
        {
            return (from record in Data.Global.context.Userstory select record).FirstOrDefault();
        }
        public static IEnumerable<Data.Userstory> LesenAttributGleich(String suchbegriff)
        {
            return (from record in Data.Global.context.Userstory where record.Title == suchbegriff select record);
        }
        public static IEnumerable<Data.Userstory> LesenAttributWie(String suchbegriff)
        {
            return (from record in Data.Global.context.Userstory where record.Title.Contains(suchbegriff) select record);
        }
        public Int64 Erstellen()
        {
            if (this.Title == null || this.Title == "") this.Title = "leer";
            if (this.Text == null) this.Text = "leer";
            Data.Global.context.Userstory.Add(this);
            Data.Global.context.SaveChanges();
            return this.UserstoryId;
        }
        public Int64 Aktualisieren()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Modified;
            Data.Global.context.SaveChanges();
            return this.UserstoryId;
        }
        public void Loeschen()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
            Data.Global.context.SaveChanges();
        }
        public override string ToString()
        {
            return UserstoryId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}