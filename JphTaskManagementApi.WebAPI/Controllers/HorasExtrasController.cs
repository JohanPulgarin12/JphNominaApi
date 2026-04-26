using JphTaskManagementApi.Domain.Models;
using JphTaskManagementApi.Domain.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Dto;

namespace JphTaskManagementApi.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class HorasExtrasController : BaseController
    {
        private readonly IConfiguration _configuration;

        public HorasExtrasController(
            IServiceProvider serviceProvider,
            IOptions<SectionConfiguration> configuration,
            IConfiguration configurationSettings)
            : base(serviceProvider, configuration)
        {
            _configuration = configurationSettings;
        }

        [HttpPost]
        [Route("UploadCsv")]
        [ProducesResponseType(200, Type = typeof(string))]
        public ActionResult<ResultOperation<string>> UploadCsv(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("Debe seleccionar un archivo CSV.");

                var response = _horasExtrasService.UploadCsv(file);

                if (!response.stateOperation)
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        response
                    );
                }

                if (!string.IsNullOrEmpty(response.MessageResult))
                {
                    return Ok(response.MessageResult);
                }

                return Ok(response.Result);
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized($"Token inválido: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar solicitud: {ex.Message}");
            }
        }
    }
}