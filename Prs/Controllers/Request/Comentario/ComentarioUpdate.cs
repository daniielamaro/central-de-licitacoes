namespace Prs.Controllers.Request.Comentario
{
    public class ComentarioUpdate
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public int Usuario { get; set; }
        public int EditalId { get; set; }
        public bool Ativo { get; set; }
    }
}
