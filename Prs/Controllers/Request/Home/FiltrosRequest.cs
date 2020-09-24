namespace Prs.Controllers.Request
{
    public class FiltrosRequest
    {
        public int? Id { get; set; }
        public string NumEdital { get; set; }
        public int? ClienteId { get; set; }
        public string DataAberturaInicio { get; set; }
        public string DataAberturaFinal { get; set; }
        public int? ModalidadeId { get; set; }
        public int? RegiaoId { get; set; }
        public int? EstadoId { get; set; }
        public int? CategoriaId { get; set; }
        public string Uasg { get; set; }
        public string Consorcio { get; set; }
        public int? PortalId { get; set; }
        public int? GerenteId { get; set; }
        public int? DiretorId { get; set; }
        public decimal? ValorEstimadoInicio { get; set; }
        public decimal? ValorEstimadoFinal { get; set; }
        public int? BuId { get; set; }
    }
}
