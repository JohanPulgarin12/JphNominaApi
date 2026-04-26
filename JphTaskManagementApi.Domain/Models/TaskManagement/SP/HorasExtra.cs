using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Domain.Models.TaskManagement.SP
{
    public class HorasExtra
    {
        public string DocumentoEmpleado { get; set; }
        public string TipoHoraExtra { get; set; }
        public decimal CantidadHoras { get; set; }
        public DateTime FechaReporte { get; set; }
    }
}
