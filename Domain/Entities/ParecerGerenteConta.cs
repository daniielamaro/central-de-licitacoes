namespace Domain.Entities
{
    public class ParecerGerenteConta : Entity
    {
        public Edital Edital { get; set; }
        public string Parecer { get; set; }
        public string Natureza { get; set; }
        public MotivosComum MotivoComum { get; set; }
        public int? Crm { get; set; }
        public string Observacao { get; set; }
        public Empresa Empresa { get; set; }
        public PreVenda PreVenda { get; set; }
        public Anexo Anexo1 { get; set; }
        public Anexo Anexo2 { get; set; }
    }
}
