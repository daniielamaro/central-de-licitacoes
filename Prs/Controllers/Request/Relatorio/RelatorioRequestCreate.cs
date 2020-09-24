namespace Prs.Controllers.Request.Relatorio
{
    public class RelatorioRequestCreate
    {
        public string NumEdital { get; set; }
        public int? ClienteId { get; set; }
        public string DataAberturaInicio { get; set; }
        public string DataAberturaFinal { get; set; }
        public int? ModalidadeId { get; set; }
        public int? RegiaoId { get; set; }
        public int? EstadoId { get; set; }
        public string Uasg { get; set; }
        public string Consorcio { get; set; }
        public int? PortalId { get; set; }
        public int? GerenteId { get; set; }
        public int? DiretorId { get; set; }
        public decimal ValorEstimadoInicio { get; set; }
        public decimal ValorEstimadoFinal { get; set; }
        public string ParecerGerente { get; set; }
        public int? MotivoComumId { get; set; }
        public int? PreVendaId { get; set; }
        public string ParecerDiretor { get; set; }
        public int? EmpresaId { get; set; }
        public int? CategoriaId { get; set; }
        public string ParecerLicitacao { get; set; }
        public int? MotivoPerdaId { get; set; }
        public decimal NossoValorInicio { get; set; }
        public decimal NossoValorFinal { get; set; }
        public int? VencedorId { get; set; }
        public decimal ValorVencedorInicio { get; set; }
        public decimal ValorVencedorFinal { get; set; }
        public int? ReponsavelId { get; set; }
        public int? BuId { get; set; }
    }
}
