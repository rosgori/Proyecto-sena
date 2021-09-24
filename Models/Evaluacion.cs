using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class Evaluacion
    {
        public Evaluacion()
        {
            Parametros = new HashSet<Parametro>();
            ResultadoEvaluacions = new HashSet<ResultadoEvaluacion>();
        }

        public uint IdEvaluacion { get; set; }
        public string NombreEvaluacion { get; set; }
        public string DescripcionEvaluacion { get; set; }

        public virtual ICollection<Parametro> Parametros { get; set; }
        public virtual ICollection<ResultadoEvaluacion> ResultadoEvaluacions { get; set; }
    }
}
