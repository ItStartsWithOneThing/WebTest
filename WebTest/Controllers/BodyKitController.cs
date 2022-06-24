using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest.Models;

namespace WebTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyKitController : ControllerBase
    {
        private static List<BodyKit> _bodies;

        private readonly ILogger<BodyKitController> _logger;

        static BodyKitController()
        {
            _bodies = new List<BodyKit>();
        }

        public BodyKitController(ILogger<BodyKitController> logger)
        {
            _logger = logger;
        }

        #region GET

        [HttpGet("GetAll")]
        public IActionResult GetAllBodies()
        {
            return Ok(_bodies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var body = _bodies.FirstOrDefault(x => x.Id == id);

            if(body != null)
            {
                _logger.LogInformation($"Succesfull GET request by id-{id}");

                return Ok(body);
            }

            _logger.LogInformation($"Unsuccessful GET request by id-{id}");
            return NotFound();
        }

        [HttpGet("GetSecond")] // Get by GETSECOND name
        public IActionResult GetSecond()
        {
            if(_bodies.Count >= 2)
            {
                return Ok(_bodies[1]);
            }

            return NotFound();
        }

        [HttpGet("{id}/{FrontBumper}")]
        public IActionResult GetByMultiple(Guid id, string frontBumper)
        {
            var kit = _bodies.FirstOrDefault(x => x.Id == id && x.FrontBumper == frontBumper);

            if(kit != null)
            {
                return Ok(kit);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult GetByQuerry([FromQuery]string frontBumper, [FromQuery]string rearBumper)
        {
            var kit = _bodies.FirstOrDefault(x => x.FrontBumper == frontBumper && x.RearBumper == rearBumper);

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
                kit.Id = Guid.NewGuid();

                _bodies.Add(kit);

                return Created(kit.Id.ToString(), kit);
            }

            return BadRequest();
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if(id != null)
            {
                var target = _bodies.FirstOrDefault(x => x.Id == id);

                if(target != null)
                {
                    _bodies.Remove(target);
                    return NoContent();
                }

                return BadRequest();
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

            var target = _bodies.FirstOrDefault(x => x.Id == kit.Id);

            if(target != null)
            {
                var index = _bodies.IndexOf(target);
                _bodies[index] = kit;

                return Ok(kit);
            }

            return NotFound();
        }
        #endregion

        #region PATCH
        [HttpPatch("front")]
        public IActionResult PartialUpdate([FromQuery] string rear, [FromQuery] string front)
        {
            var target = _bodies.FirstOrDefault(x => x.RearBumper == rear);
            target.FrontBumper = front;

            return Ok(target);
        }
        #endregion
    }
}
