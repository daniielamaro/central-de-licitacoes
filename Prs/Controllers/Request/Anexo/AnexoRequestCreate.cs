namespace Prs.Controllers.Request
{
    public class AnexoRequestCreate
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public byte[] Base64 { get; set; }
    }
}
