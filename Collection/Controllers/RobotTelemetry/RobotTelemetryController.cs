using Collection.Service.RobotTelemetry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Collection.DTO.RobotTelemetry;
namespace Collection.Controllers.RobotTelemetry
{
    [Route("api/robot/{robotId:guid}/telemetry")]
    [ApiController]
    public class RobotTelemetryController : ControllerBase
    {
        private readonly IRobotTelemetryService _robTelemService;

        public RobotTelemetryController(IRobotTelemetryService robTelemService)
        {
            _robTelemService = robTelemService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            try
            {
                var result = await _robTelemService.GetAllAsync(ct);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct = default)
        {
            try
            {
                var result = await _robTelemService.GetByIdAsync(id, ct);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
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
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(
            Guid robotId,
            RobotTelemetryRequestDTO request,
            CancellationToken ct = default)
            {
            try
            { 
                await _robTelemService.CreateAsync(request, robotId, ct);
                return Accepted();
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

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(
            Guid id,
            RobotTelemetryUpdateDTO update,
            CancellationToken ct = default)
        {
            try
            {
                await _robTelemService.UpdateAsync(id, update, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct = default)
        {
            try
            {
                await _robTelemService.DeleteAsync(id, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
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
