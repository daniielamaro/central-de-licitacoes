namespace Prs.Controllers.Request.Cliente
{
    public class ClienteRequestUpdate
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
    }
}
