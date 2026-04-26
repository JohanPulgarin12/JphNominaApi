using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Infrastructure.Repositories.Interfaces
{
    public interface IHorasExtrasRepository
    {
        bool InsertHoraExtra(HorasExtra item);
        bool InsertHoraExtraError(HorasExtraError item);
    }
}
