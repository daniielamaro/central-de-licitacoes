namespace Domain.Entities
{
    public class ParecerLicitacao : Entity
    {
        public Edital Edital { get; set; }
        public string Resultado { get; set; }
        public decimal? NossoValor { get; set; }
        public MotivosPerda MotivoPerda { get; set; }
        public Concorrente Vencedor { get; set; }
        public decimal? ValorVencedor { get; set; }
        public int? NossaClassificacao { get; set; }
        public string Observacao { get; set; }
        public Usuario Responsavel { get; set; }
        public Anexo Anexo1 { get; set; }
        public Anexo Anexo2 { get; set; }
    }
}
