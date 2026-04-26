using JphTaskManagementApi.Application.Services.Interfaces;
using JphTaskManagementApi.Domain.Models;
using JphTaskManagementApi.Domain.Models.Dto;
using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using JphTaskManagementApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Application.Services
{
    public class HorasExtrasService: _Service, IHorasExtrasService
    {
        public HorasExtrasService(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings.Value.ConnetionGenerico)
        {

        }
        public ResultOperation<string> UploadCsv(IFormFile file)
        {
            var result =
            WrapExecuteTrans<ResultOperation<string>, HorasExtrasRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<string>();

                try
                {
                    using var reader = new StreamReader(file.OpenReadStream());

                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        var doc = values[0]?.Trim();
                        var tipo = values[1]?.Trim();
                        var horas = values[2]?.Trim();
                        var fecha = values[3]?.Trim();

                        var error = Validar(doc, tipo, horas, fecha);

                        if (string.IsNullOrEmpty(error))
                        {
                            repo.InsertHoraExtra(new HorasExtra
                            {
                                DocumentoEmpleado = doc,
                                TipoHoraExtra = tipo,
                                CantidadHoras = Convert.ToDecimal(horas),
                                FechaReporte = Convert.ToDateTime(fecha)
                            });
                        }
                        else
                        {
                            repo.InsertHoraExtraError(new HorasExtraError
                            {
                                DocumentoEmpleado = doc,
                                TipoHoraExtra = tipo,
                                CantidadHoras = horas,
                                FechaReporte = fecha,
                                MotivoError = error
                            });
                        }
                    }

                    rst.Result = "Archivo procesado correctamente";
                    rst.stateOperation = true;
                }
                catch (Exception ex)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.MessageExceptionTechnical = ex.Message;
                }

                return rst;
            });

            return result;
        }

        private string Validar(string doc, string tipo, string horas, string fecha)
        {
            if (string.IsNullOrWhiteSpace(doc))
                return "Documento vacío";

            if (!decimal.TryParse(horas, out decimal h))
                return "Horas inválidas";

            if (h <= 0)
                return "Horas <= 0";

            string[] tipos =
            {
                "HE_DIURNA",
                "HE_NOCTURNA",
                "HE_DOMINICAL",
                "HE_FESTIVA"
            };

            if (!tipos.Contains(tipo))
                return "Tipo inválido";

            if (!DateTime.TryParse(fecha, out _))
                return "Fecha inválida";

            return "";
        }
    }
}
