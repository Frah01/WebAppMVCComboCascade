using System.ComponentModel.DataAnnotations;

namespace WebAppMVCComboCascade.Models
{
    public class Comune
    {
        public int ID { get; set; }

        [Display(Name = "Comune")]
        public string Nome { get; set; }

        [Display(Name = "Id Provincia")]
        public int IdProvincia { get; set; }

        [Display(Name = "Num. Abitanti")]
        public int NumAbitanti { get; set; }
    }
}
