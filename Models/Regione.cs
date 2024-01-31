using System.ComponentModel.DataAnnotations;

namespace WebAppMVCComboCascade.Models
{
    public class Regione
    {
        public int ID { get; set; }

        [Display(Name = "Regione")] //MODIFICARE IL NOME VISUALIZZATO A SCHERMO
        public string Nome { get; set; }

        [Display(Name = "E', Autonoma")]
        public bool isAutonoma { get; set; }
        
        [Display(Name = "Num. Abitanti")]
        public int NumAbitanti { get; set; }
        
    }
}
