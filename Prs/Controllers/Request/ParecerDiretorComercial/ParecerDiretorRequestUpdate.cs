namespace Prs.Controllers.Request
{
    public class ParecerDiretorRequestUpdate
    {
        public int ResponsavelRequestId { get; set; }
        public int Id { get; set; }
        public string Decisao { get; set; }
        public int EmpresaId { get; set; }
        public int? MotivoComumId { get; set; }
        public int GerenteId { get; set; }
        public string Observacao { get; set; }
        public AnexoRequestUpdate Anexo1 { get; set; }
        public AnexoRequestUpdate Anexo2 { get; set; }
        public bool Ativo { get; set; }
    }
}
