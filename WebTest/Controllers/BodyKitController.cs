using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest.Models;
using WebTestBL;

namespace WebTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyKitController : ControllerBase
    {

        private readonly BodyKitService _bodyKitService;
        private readonly ILogger<BodyKitController> _logger;


        public BodyKitController(ILogger<BodyKitController> logger, BodyKitService bodyKitService)
        {
            _logger = logger;
            _bodyKitService = bodyKitService;
        }

        #region GET

        [HttpGet("GetAll")]
        public IActionResult GetAllBodies()
        {
            return Ok(_bodyKitService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var body = _bodyKitService.GetByID(id);

            if(body != null)
            {
                _logger.LogInformation($"Succesfull GET request by id-{id}");

                return Ok(body);
            }

            _logger.LogInformation($"Unsuccessful GET request by id-{id}");
            return NotFound();
        }

        
        [HttpGet("{id}/{RearBumper}")]
        public IActionResult GetBySeveralParams(Guid id, string rearBumper) // Existing for instance
        {
            var kit = _bodyKitService.GetBySeveralParams(id, rearBumper);

            if(kit != null)
            {
                return Ok(kit);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult GetByQuerry([FromQuery]Guid id, [FromQuery]string rearBumper) // Existing for instance
        {
            var kit = _bodyKitService.GetByQuerryString(id, rearBumper);

            if (kit != null)
            {
                return Ok(kit);
            }

            return NotFound();
        }

        #endregion

        #region POST
        [HttpPost]
        public IActionResult Add(BodyKit kit)
        {
            if(kit != null)
            {
                var createdGuid = _bodyKitService.AddKit(kit);

                return Created(createdGuid.ToString(), kit);
            }

            return BadRequest();
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            if(id != null)
            {
                var target = _bodyKitService.RemoveKit(id);

                if(target)
                {
                    return NoContent();
                }

                return NotFound();
            }

            return BadRequest();
        }
        #endregion

        #region PUT
        [HttpPut]
        public IActionResult Update(BodyKit kit)
        {
            if(kit == null)
            {
                return BadRequest();
            }

            var target = _bodyKitService.UpdateKit(kit);

            if(target)
            {
                return Ok(kit);
            }

            return NotFound();
        }
        #endregion

        #region PATCH
        [HttpPatch("front")]
        public IActionResult UpdateRearBumper([FromQuery] Guid id, [FromQuery] string rearBumper)
        {
            var target = _bodyKitService.UpdateRearBumper(id, rearBumper);

            return Ok(target);
        }
        #endregion
    }
}
