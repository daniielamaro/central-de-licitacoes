namespace Prs.Controllers.Request
{
    public class ParecerGerenteRequestCreate
    {
        public int ResponsavelRequestId { get; set; }
        public int EditalId { get; set; }
        public string Parecer { get; set; }
        public string Natureza { get; set; }
        public int? MotivoComumId { get; set; }
        public int? Crm { get; set; }
        public string Observacao { get; set; }
        public int EmpresaId { get; set; }
        public int? PreVendaId { get; set; }
        public AnexoRequestCreate Anexo1 { get; set; }
        public AnexoRequestCreate Anexo2 { get; set; }
    }
}
