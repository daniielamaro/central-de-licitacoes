using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Edital : Entity
    {
        public string NumEdital { get; set; }
        public Cliente Cliente { get; set; }
        public Estado Estado { get; set; }
        public Modalidade Modalidade { get; set; }
        public Etapa Etapa { get; set; }
        public DateTime DataHoraDeAbertura { get; set; }
        public string Uasg { get; set; }
        public Categoria Categoria { get; set; }
        public string Consorcio { get; set; }
        public decimal? ValorEstimado { get; set; }
        public string AgendarVistoria { get; set; }
        public DateTime? DataVistoria { get; set; }
        public string ObjetosDescricao { get; set; }
        public string ObjetosResumo { get; set; }
        public string Observacoes { get; set; }
        public Regiao Regiao { get; set; }
        public Usuario Gerente { get; set; }
        public Usuario Diretor { get; set; }
        public Portal Portal { get; set; }
        public Anexo Anexo { get; set; }
        public List<Comentario> Comentarios { get; set; } 
    }
}
