using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Book
    {
        public Guid ID { get; set; }

        [DisplayName("Titel")]
        [MaxLength (50, ErrorMessage ="der Titel darf maximal nur 10 Zeichen lang sein") ]
        public string Title { get; set; }


        [DisplayName("Autor")]
        public string Author { get; set; }


        [DisplayName("Preis")]
        [Required(ErrorMessage ="Bitte geben Sie einen Preis ein")]
        //[Range (5, 15, ErrorMessage = "Bitte einen Wert zwishcen 5 und 15 Euro eingeben")]
        
        public decimal Price { get; set; }

        //[EmailAddress]
        //public string EmailAdress { get; set; }

        [DisplayName("Veröffentlichung")]
        [Required(ErrorMessage = "Bitte geben Sie einen Veröffentlichungsdatum ein")]
        public DateTime Published { get; set; }

        public bool AudioBook { get; set; } = false;

        public string PictureName { get; set; } //-> ID + BildFormat-Extentions -> Beispiel 1: 11.jpg ODER Beispiel 2: 11.gif 
    }
}
