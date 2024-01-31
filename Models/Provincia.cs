namespace WebAppMVCComboCascade.Models
{
    public class Provincia
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int IdRegione { get; set; }
        public bool isCapoluogo { get; set; }
        public int NumAbitanti { get; set; }
    }
}
