namespace Prs.Controllers.Request.Comentario
{
    public class ComentarioCreate
    {
        public string Mensagem { get; set; }
        public int Usuario { get; set; }
        public int EditalId { get; set; }
    }
}
