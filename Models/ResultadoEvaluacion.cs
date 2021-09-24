using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_Sena_2.Models
{
    public partial class ResultadoEvaluacion
    {
        public string IdCompañia { get; set; }
        public uint IdEvaluacion { get; set; }
        public bool Aprobado { get; set; }
        public DateTime FechaAprobado { get; set; }
        public sbyte Calificacion { get; set; }

        public virtual Compañium IdCompañiaNavigation { get; set; }
        public virtual Evaluacion IdEvaluacionNavigation { get; set; }
    }
}
