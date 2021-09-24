using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class Parametro
    {
        public uint IdParametro { get; set; }
        public string NombreParametro { get; set; }
        public string DescripcionParametro { get; set; }
        public uint IdEvaluacion { get; set; }
        public sbyte CalificacionParametro { get; set; }

        public virtual Evaluacion IdEvaluacionNavigation { get; set; }
    }
}
