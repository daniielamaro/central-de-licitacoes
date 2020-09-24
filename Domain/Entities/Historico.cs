namespace Domain.Entities
{
    public class Historico : Entity
    {
        public string Descricao { get; set; }
        public Usuario Responsavel { get; set; }
        public Edital Edital { get; set; }
    }
}
