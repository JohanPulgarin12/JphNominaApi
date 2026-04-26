using JphTaskManagementApi.Domain.Models.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Application.Services.Interfaces
{
    public interface IHorasExtrasService
    {
        ResultOperation<string> UploadCsv(IFormFile file);

    }
}
