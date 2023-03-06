using Carshop.Models;
using CarShop1.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarShop1.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    //URL:api/cars
    [ApiController]
    public class CarController : ControllerBase
    {
        private Repositories? _repository;

        public CarController(Repositories repository) 
        {
          _repository = repository;
        }
        // GET: api/<ValuesController>
       
        
       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [EnableCors]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAlle([FromHeader] int?amount,
                                                       [FromQuery] string? model,
                                                       [FromQuery] int?minprice,
                                                       [FromQuery] int?maxprice)
        {
            List<Car> result = _repository.GetAlle( amount,model,minprice,maxprice);
            if(result.Count < 1 )
            {
                return NotFound();
            }
            Response.Headers.Add("TotalAmount", "" + result.Count());
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Car> Get(int id)
        {
            Car foundcar = _repository.GetCarByID(id);
            if(foundcar == null)
            {
                return NotFound(id);
            }
            return Ok(foundcar);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Car> Post([FromBody] Car newcar)
        {
            try
            {
                Car createCar = _repository.Add(newcar);
                return Created($"api/cars/{createCar.Id}",createCar);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Car> Put(int id, [FromBody]Car updates)
        {
            try
            {
                Car? updateCar = _repository.Update(id, updates);
                if(updateCar == null)
                {
                    return NotFound(id);
                }
                return Ok(updateCar);
                
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // DELETE api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car? DeleteCar = _repository.Delete(id);
            if(DeleteCar == null)
            {
                return NotFound(id);
            }
            return Ok(DeleteCar);
        }
    }
}
