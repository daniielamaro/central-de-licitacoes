namespace Domain.Entities
{
    public class ParecerDiretorComercial : Entity
    {
        public Edital Edital { get; set; }
        public string Decisao { get; set; }
        public Empresa Empresa { get; set; }
        public MotivosComum MotivosComum { get; set; }
        public Usuario Gerente { get; set; }
        public string Observacao { get; set; }
        public Anexo Anexo1 { get; set; }
        public Anexo Anexo2 { get; set; }
    }
}
