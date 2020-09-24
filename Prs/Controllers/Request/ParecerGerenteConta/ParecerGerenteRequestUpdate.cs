namespace Prs.Controllers.Request
{
    public class ParecerGerenteRequestUpdate
    {
        public int ResponsavelRequestId { get; set; }
        public int Id { get; set; }
        public string Parecer { get; set; }
        public string Natureza { get; set; }
        public int? MotivoComumId { get; set; }
        public int? Crm { get; set; }
        public string Observacao { get; set; }
        public int EmpresaId { get; set; }
        public int? PreVendaId { get; set; }
        public AnexoRequestUpdate Anexo1 { get; set; }
        public AnexoRequestUpdate Anexo2 { get; set; }
        public bool Ativo { get; set; }
    }
}
