namespace Prs.Controllers.Request.Concorrente
{
    public class ConcorrenteRequestCreate
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
    }
}
