using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailRay.API.Data;
using RailRay.API.Models.Domain;
using RailRay.API.Models.DTOs;

namespace RailRay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase

    {
        private readonly RailRayDbContext dbContext;


        public TrainController(RailRayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //GET ALL TRAINS

        [HttpGet]
        public IActionResult GetAllTrains()
        {

            //Get Data from Database - Domain models
            var trainsDomain = dbContext.Trains.ToList();

            //Map Domain Models to DTOs
            var trainsDto = new List<TrainDto>();
            foreach (var trainDomain in trainsDomain)
            {
                trainsDto.Add(new TrainDto()
                {
                    TrainNumber = trainDomain.TrainNumber,
                    Name = trainDomain.Name,
                    Type = trainDomain.Type,


                });
            }





            //return DTOs 

            return Ok(trainsDto);

        }

        //GET SINGLE TRAIN
        [HttpGet]
        [Route("{id:Guid}")]

        public IActionResult GetById([FromRoute] Guid id)
        {
            //var train = dbContext.Trains.Find(id);
            //Get Train Domain Model From Database
            var trainDomain = dbContext.Trains.FirstOrDefault(x => x.Id == id);

            if (trainDomain == null)
            {
                return NotFound();
            }

            //Map/Convert Train Model to Train DTO

            var trainDto = new TrainDto
            {
                TrainNumber = trainDomain.TrainNumber,
                Name = trainDomain.Name,
                Type = trainDomain.Type,
            };

            return Ok(trainDto);
        }

        //POST to Create New Train
        [HttpPost]
        public IActionResult Create([FromBody] AddTrainRequestDto addTrainRequestDto)

        {
            // Map or Convert DTO to Domain Model
            //Map/Convert Train Model to Train DTO

            var trainDomainModel = new Train
            {
                TrainNumber = addTrainRequestDto.TrainNumber,
                Name = addTrainRequestDto.Name,
                Type = addTrainRequestDto.Type,
            };

            //Use Domain Model to Create Train

            dbContext.Trains.Add(trainDomainModel);
            dbContext.SaveChanges();

            //Map Domain Model back to DTO
            var trainDto = new TrainDto
            {
                TrainNumber = trainDomainModel.TrainNumber,
                Name = trainDomainModel.Name,
                Type = trainDomainModel.Type,
            };

            return CreatedAtAction(nameof(GetById), trainDto);

        }



        //PUT Update a Train
        [HttpPut]
        [Route("{id:Guid}")]

        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateTrainRequestDto updateTrainRequestDto)
        {
            //Fibd the train
            var existingTrain = dbContext.Trains.FirstOrDefault(x => x.Id == id);

            if (existingTrain == null)
            {
                return NotFound();
            }


            //Update fields
            existingTrain.TrainNumber = updateTrainRequestDto.TrainNumber;
            existingTrain.Name = updateTrainRequestDto.Name;
            existingTrain.Type = updateTrainRequestDto.Type;

            dbContext.SaveChanges();



            //Convert to DTO and return

            var trainDto = new TrainDto
            {
                TrainNumber = existingTrain.TrainNumber,
                Name = existingTrain.Name,
                Type = existingTrain.Type,
            };

            return Ok(trainDto);


        }


        //DELETE to Delete a Train
        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult Delete([FromRoute] Guid id)
        {
            var train = dbContext.Trains.FirstOrDefault(x => x.Id == id);
            if (train == null) { 
                return NotFound();
            }


            dbContext.Trains.Remove(train);
            dbContext.SaveChanges();

            return NoContent();
        }


    }
}
