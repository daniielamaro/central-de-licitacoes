namespace Prs.Controllers.Request.Categoria
{
    public class CategoriaRequestUpdate
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int BuId { get; set; }
        public bool Ativo { get; set; }
    }
}
