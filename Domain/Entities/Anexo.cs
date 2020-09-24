namespace Domain.Entities
{
    public class Anexo : Entity
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public byte[] Base64 { get; set; }
    }
}
