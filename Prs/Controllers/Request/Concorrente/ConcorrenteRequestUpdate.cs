namespace Prs.Controllers.Request.Concorrente
{
    public class ConcorrenteRequestUpdate
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
    }
}
