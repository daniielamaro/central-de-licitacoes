namespace Prs.Controllers.Request
{
    public class ParecerLicitacaoRequestCreate
    {
        public int ResponsavelRequestId { get; set; }
        public int EditalId { get; set; }
        public string Resultado { get; set; }
        public decimal? NossoValor { get; set; }
        public int? MotivosPerdaId { get; set; }
        public int? VencedorId { get; set; }
        public decimal? ValorVencedor { get; set; }
        public int? NossaClassificacao { get; set; }
        public string Observacao { get; set; }
        public int ResponsavelId { get; set; }
        public AnexoRequestUpdate Anexo1 { get; set; }
        public AnexoRequestUpdate Anexo2 { get; set; }
    }
}
