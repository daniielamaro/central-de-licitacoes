namespace Prs.Controllers.Request
{
    public class ParecerDiretorRequestCreate
    {
        public int ResponsavelRequestId { get; set; }
        public int EditalId { get; set; }
        public string Decisao { get; set; }
        public int EmpresaId { get; set; }
        public int? MotivosComumId { get; set; }
        public int GerenteId { get; set; }
        public string Observacao { get; set; }
        public AnexoRequestCreate Anexo1 { get; set; }
        public AnexoRequestCreate Anexo2 { get; set; }
    }
}
