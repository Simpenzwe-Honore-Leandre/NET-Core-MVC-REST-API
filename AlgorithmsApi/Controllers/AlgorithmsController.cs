using System;
using Algorithms.Data;
using Algorithms.Dtos;
using Algorithms.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Controllers
{
    //routes and corresponding are unique
    [Route("api/v1/Algorithms")]
    public class AlgorithmsController : ControllerBase
    {
        private readonly IAlgorithmRepo _repository;
        private readonly IMapper _mapper;

        public AlgorithmsController(IAlgorithmRepo repository, IMapper mapper)
        {
            _repository = repository;   
            _mapper = mapper;
        }

        // private readonly MockLeandreRepo _repository = new MockLeandreRepo();
        //GET http request to get API commands
        [HttpGet]
        public ActionResult <IEnumerable<AlgorithmReadDto>> GetAllAlgorithms()
        {
            var AlgorithmItems =  _repository.GetAllAlgorithms();
            
            if(AlgorithmItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<AlgorithmReadDto>>(AlgorithmItems));
            }
            return NotFound();
        }
        
        //provides a route to ActionResult <Command> GetCommandById(int id)
        //alternatively one can use [HttpGet("{id}")]. Similarly Guest request will respond to URI api/commands/{id}
        //id passed using postman

        // [HttpGet("{id})]
        [HttpGet("algoid/{Id}", Name = "GetById")]
        public ActionResult<AlgorithmReadDto> GetById(int Id)
        {
            var AlgorithmItem = _repository.GetAlgorithmById(Id);
            if (AlgorithmItem != null)
            {
                return Ok(_mapper.Map<AlgorithmReadDto>(AlgorithmItem));
            }
            return NotFound();
        }

        [HttpGet("algoname/{name}", Name = "GetByName")]
        public ActionResult<AlgorithmReadDto> GetByName(string name)
        {
            var AlgorithmItem = _repository.GetAlgorithmByName(name);
            if (AlgorithmItem != null)
            {
                return Ok(_mapper.Map<AlgorithmReadDto>(AlgorithmItem));
            }
            return NotFound();
        }

        [HttpPost]

        public ActionResult<AlgorithmReadDto> CreateAlgorithm([FromBody]AlgorithmCreateDto algodto)
        {
            var AlgorithmModel = _mapper.Map<Algorithm>(algodto);

            _repository.CreateAlgorithm(AlgorithmModel);

            _repository.ValidateSaveChanges();

            var algorithmReadDtoReturned = _mapper.Map<AlgorithmReadDto>(AlgorithmModel);

            //passing 201 created code with uri that can be used to get the created dto
            return CreatedAtRoute(nameof(GetByName), new { name = algorithmReadDtoReturned.algorithmname }, algorithmReadDtoReturned);
        }


        //passes back the entire object to update
        [HttpPut("{Id}")]
        public ActionResult UpdateAlgorithm(int Id, [FromBody]AlgorithmPutDto algo)
        {
            var AlgorithmItem = _repository.GetAlgorithmById(Id);

            if(AlgorithmItem.algorithmname == null || AlgorithmItem.description == null || AlgorithmItem.usecases==null)
            {
                return NotFound();
            }

            _mapper.Map(algo, AlgorithmItem);

            _repository.UpdateAlgorithm(AlgorithmItem);

            _repository.ValidateSaveChanges();

            return NoContent();
        }

        //more efficient saves only selecty parts of object attribute
        [HttpPatch("{Id}")]
        public ActionResult PartialUpdateAlgorithm(int Id, [FromBody]JsonPatchDocument<AlgorithmPutDto> patchDoc)
        {
            var AlgorithmItem = _repository.GetAlgorithmById(Id);

            if(AlgorithmItem == null)
            {
                return NotFound();
            }

            var AlgorithmToPatch = _mapper.Map<AlgorithmPutDto>(AlgorithmItem);

            patchDoc.ApplyTo(AlgorithmToPatch, ModelState);

            if(!TryValidateModel(AlgorithmToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(AlgorithmToPatch, AlgorithmItem);

            _repository.UpdateAlgorithm(AlgorithmItem);

            _repository.ValidateSaveChanges();

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public ActionResult<Algorithm> DeleteAlgorithm(int Id)
        {
            var AlgorithmItem = _repository.GetAlgorithmById(Id);

            if(AlgorithmItem == null)
            {
                return NotFound();
            }

            var algorithmReadDtoReturned = _mapper.Map<AlgorithmReadDto>(AlgorithmItem);

            _repository.DeleteAlgorithm(AlgorithmItem);

            _repository.ValidateSaveChanges();

            return Ok(algorithmReadDtoReturned);
        }
    }
}