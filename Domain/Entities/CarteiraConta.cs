namespace Domain.Entities
{
    public class CarteiraConta : Entity
    {
        public Usuario Gerente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
