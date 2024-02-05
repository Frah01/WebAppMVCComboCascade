using System.ComponentModel.DataAnnotations;

namespace WebAppMVCComboCascade.Models
{
    public class Comune
    {
        [Required]
        public int ID { get; set; }

        [Display(Name = "Comune")]
        public string Nome { get; set; }

        [Display(Name = "Id Provincia")]
        public int IdComune { get; set; }

        [Display(Name = "Num. Abitanti")]
        public int NumAbitanti { get; set; }
    }
}
