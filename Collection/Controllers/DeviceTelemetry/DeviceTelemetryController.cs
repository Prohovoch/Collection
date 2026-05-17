using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Collection.Service.DeviceTelemetry;
using Collection.DTO.DeviceTelemetry;
namespace Collection.Controllers.DeviceTelemetry
{
    [Route("api/device/{deviceId:guid}/telemetry")]
    [ApiController]
    public class DeviceTelemetryController : ControllerBase
    {
        private readonly IDeviceTelemetryService _devTelemService;

        public DeviceTelemetryController(IDeviceTelemetryService devTelemService)
        {
            _devTelemService = devTelemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            try
            {
                var result = await _devTelemService.GetAllAsync(ct);
                return Ok(result);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct = default)
        {
            try
            {
                var result = await _devTelemService.GetByIdAsync(id, ct);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            Guid deviceId,
            DeviceTelemetryRequestDTO request,
            CancellationToken ct = default)
        {
            try
            {
                await _devTelemService.CreateAsync(request, deviceId, ct);
                return Ok();
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            DeviceTelemtryUpdateDTO update,
            CancellationToken ct)
        {
            try
            {
                await _devTelemService.UpdateAsync(id, update, ct);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            try
            {
                await _devTelemService.DeleteAsync(id, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
