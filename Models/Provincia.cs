using System.ComponentModel.DataAnnotations;

namespace WebAppMVCComboCascade.Models
{
    public class Provincia
    {
        [Required]
        public int ID { get; set; }

        [Display(Name = "Provincia")]
        public string Nome { get; set; }

        [Display(Name = "Id Regione")]
        public int IdRegione { get; set; }

        [Display(Name = "E' Capoluogo")]
        public bool isCapoluogo { get; set; }

        [Display(Name = "Num. Abitanti")]
        public int NumAbitanti { get; set; }
    }
}
