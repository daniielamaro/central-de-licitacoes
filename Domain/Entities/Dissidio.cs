using System;

namespace Domain.Entities
{
    public class Dissidio : Entity
    {
        public Estado Estado { get; set; }
        public DateTime? DataBase { get; set; }
        public DateTime? DataUltima { get; set; }
        public decimal? PisoSalarial8h { get; set; }
        public decimal? PisoSalarial6h { get; set; }
        public decimal? Ticket8h { get; set; }
        public decimal? Ticket6h { get; set; }
        public decimal? BenefInd8h { get; set; }
        public decimal? BenefInd6h { get; set; }
        public decimal? Reajuste { get; set; }
        public string Observacoes { get; set; }
        public DateTime? VigenciaInicio { get; set; }
        public DateTime? VigenciaFinal { get; set; }
        public string Cnpj { get; set; }
        public string ConformeCargoFuncao { get; set; }
        public Anexo Arquivo { get; set; }
        public string Atalho { get; set; }
    }
}
