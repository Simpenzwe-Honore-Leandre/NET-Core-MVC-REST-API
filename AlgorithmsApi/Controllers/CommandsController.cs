using Algorithms.Data;
using Algorithms.Models;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Controllers
{
    //routes and corresponding are unique
    [Route("api/Algorithms")]
    public class AlgorithmsController : ControllerBase
    {
        private readonly MockAlgorithmRepo _repository = new MockAlgorithmRepo();

        public AlgorithmsController(MockAlgorithmRepo repository)
        {
            _repository = repository;   
        }

        // private readonly MockLeandreRepo _repository = new MockLeandreRepo();
        //http request to get API commands
        [HttpGet]
        public ActionResult <IEnumerable<Algorithm>> GetAllAlgorithms()
        {
            var commandItems =  _repository.GetAppAlgorithms();
            
            return Ok(commandItems);
        }
        
        //provides a route to ActionResult <Command> GetCommandById(int id)
        //alternatively one can use [HttpGet("{id}")]. Similarly Guest request will respond to URI api/commands/{id}
        //id passed using postman

        // [HttpGet]

        [HttpGet("{id}")]
        
        public ActionResult <Algorithm> GetById(int id)
        {   
            var commandItem =  _repository.GetAlgorithmById(id);
            return Ok(commandItem);
        }

    }
}