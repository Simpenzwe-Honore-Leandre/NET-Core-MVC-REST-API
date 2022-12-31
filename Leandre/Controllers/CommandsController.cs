using Leandre.Models;
using Leandre.Data;
using Microsoft.AspNetCore.Mvc;

namespace Leandre.Controllers
{
    //routes and corresponding are unique
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ILeandreRepo _repository;

        public CommandsController(ILeandreRepo repository)
        {
            _repository = repository;   
        }

        // private readonly MockLeandreRepo _repository = new MockLeandreRepo();
        //http request to get API commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems =  _repository.GetAppCommands();
            
            return Ok(commandItems);
        }
        
        [Route("api/commands/{id}")]//provides a route to ActionResult <Command> GetCommandById(int id)
        //alternatively one can use [HttpGet("{id}")]. Similarly Guest request will respond to URI api/commands/{id}
        //id passed using postman

        // [HttpGet]
        [HttpGet("{id}")]
        
        public ActionResult <Command> GetCommandById(int id)
        {   
            var commandItem =  _repository.GetCommandById(id);
            return Ok(commandItem);
        }

    }
}