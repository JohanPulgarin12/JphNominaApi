using Dapper;
using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using JphTaskManagementApi.Infrastructure.Repositories._UnitOfWork;
using JphTaskManagementApi.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Infrastructure.Repositories
{
    public class HorasExtrasRepository : Repository, IHorasExtrasRepository
    {
        public HorasExtrasRepository() { }
        public HorasExtrasRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public bool InsertHoraExtra(HorasExtra item)
        {
            var prms = new DynamicParameters();

            prms.Add("DocumentoEmpleado", item.DocumentoEmpleado);
            prms.Add("TipoHoraExtra", item.TipoHoraExtra);
            prms.Add("CantidadHoras", item.CantidadHoras);
            prms.Add("FechaReporte", item.FechaReporte);

            return Execute<int>("sp_InsertHoraExtra", prms) > 0;
        }

        public bool InsertHoraExtraError(HorasExtraError item)
        {
            var prms = new DynamicParameters();

            prms.Add("DocumentoEmpleado", item.DocumentoEmpleado);
            prms.Add("TipoHoraExtra", item.TipoHoraExtra);
            prms.Add("CantidadHoras", item.CantidadHoras);
            prms.Add("FechaReporte", item.FechaReporte);
            prms.Add("MotivoError", item.MotivoError);

            return Execute<int>("sp_InsertHoraExtraError", prms) > 0;
        }

    }
}
