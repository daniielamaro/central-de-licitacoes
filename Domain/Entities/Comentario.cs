namespace Domain.Entities
{
    public class Comentario : Entity
    {
        public string Mensagem { get; set; }
        public Usuario Usuario { get; set; }
    }
}
