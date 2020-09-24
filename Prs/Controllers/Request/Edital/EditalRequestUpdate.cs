namespace Prs.Controllers.Request
{
    public class EditalRequestUpdate
    {
        public int ResponsavelRequestId { get; set; }
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string NumEdital { get; set; }
        public int ClienteId { get; set; }
        public int EstadoId { get; set; }
        public int ModalidadeId { get; set; }
        public int EtapaId { get; set; }
        public string DataDeAbertura { get; set; }
        public string HoraDeAbertura { get; set; }
        public string Uasg { get; set; }
        public int CategoriaId { get; set; }
        public string Consorcio { get; set; }
        public decimal ValorEstimado { get; set; }
        public string AgendarVistoria { get; set; }
        public string DataVistoria { get; set; }
        public string ObjetosDescricao { get; set; }
        public string ObjetosResumo { get; set; }
        public string Observacoes { get; set; }
        public int RegiaoId { get; set; }
        public int GerenteId { get; set; }
        public int DiretorId { get; set; }
        public int PortalId { get; set; }
        public AnexoRequestUpdate Anexo { get; set; }
    }
}
