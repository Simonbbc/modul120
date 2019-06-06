using System;
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
        public Boolean ShowInBacklog { get; set; }
        [Required]
        public String DefinitionOfDone { get; set; }
        [Required]
        public Int64 StoryPoints { get; set; }
        [Required]
        public String Phase { get; set; }
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
            return (from record in Data.Global.Context.Userstory select record);
        }
        public static Data.Userstory LesenID(Int64 userstoryId)
        {
            return (from record in Data.Global.Context.Userstory where record.UserstoryId == userstoryId select record).FirstOrDefault();
        }
        public static Data.Userstory LesenFirst()
        {
            return (from record in Data.Global.Context.Userstory select record).FirstOrDefault();
        }
        public static IEnumerable<Data.Userstory> LesenAttributGleich(String suchbegriff)
        {
            return (from record in Data.Global.Context.Userstory where record.Title == suchbegriff select record);
        }
        public static IEnumerable<Data.Userstory> LesenAttributWie(String suchbegriff)
        {
            return (from record in Data.Global.Context.Userstory where record.Title.Contains(suchbegriff) select record);
        }
        public Int64 Erstellen()
        {
            if (this.Title == null || this.Title == "") this.Title = "leer";
            if (this.Text == null) this.Text = "leer";
            if (this.DefinitionOfDone == null) this.DefinitionOfDone = "leer";
            Data.Global.Context.Userstory.Add(this);
            Data.Global.Context.SaveChanges();
            return this.UserstoryId;
        }
        public Int64 Aktualisieren()
        {
            Data.Global.Context.Entry(this).State = System.Data.Entity.EntityState.Modified;
            Data.Global.Context.SaveChanges();
            return this.UserstoryId;
        }
        public void Loeschen()
        {
            Data.Global.Context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
            Data.Global.Context.SaveChanges();
        }
        public override string ToString()
        {
            return UserstoryId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
