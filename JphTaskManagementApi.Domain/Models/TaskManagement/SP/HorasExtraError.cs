using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Domain.Models.TaskManagement.SP
{
    public class HorasExtraError
    {
        public string DocumentoEmpleado { get; set; }
        public string TipoHoraExtra { get; set; }
        public string CantidadHoras { get; set; }
        public string FechaReporte { get; set; }
        public string MotivoError { get; set; }
    }
}
