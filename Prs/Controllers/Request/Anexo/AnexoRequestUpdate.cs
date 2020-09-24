namespace Prs.Controllers.Request
{
    public class AnexoRequestUpdate
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public byte[] Base64 { get; set; }
        public bool Ativo { get; set; }
    }
}
