using Microsoft.AspNetCore.Mvc;
using RailRay.API.Data;
using RailRay.API.Models.Domain;
using RailRay.API.Models.DTOs;

namespace RailRay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TrainScheduleController : ControllerBase
    {
        private readonly RailRayDbContext dbContext;
        public TrainScheduleController(RailRayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //GET to get all scedules
        public IActionResult GetAllSchedules()
        {
            var schedules = dbContext.Scedules.ToList();

            var dtoList = schedules.Select(s => new TrainScheduleDto
            {
                Id = s.Id,
                TrainId = s.TrainId,
                FromStationId = s.FromStationId,
                ToStationId = s.ToStationId,
                DepartureDate = s.DepartureDate,
                DepartureTime = s.DepartureTime,
                ArrivalTime = s.ArrivalTime
            }).ToList();

            return Ok(dtoList);

        }

        //GET a schedule
        [HttpGet]
        [Route("{id:Guid}")]

        public IActionResult GetById([FromRoute] Guid id)
        {
            var schedule = dbContext.Scedules.FirstOrDefault(s => s.Id == id);

            if (schedule == null)
                return NotFound();

            var dto = new TrainScheduleDto
            {
                Id = schedule.Id,
                TrainId = schedule.TrainId,
                FromStationId = schedule.FromStationId,
                ToStationId = schedule.ToStationId,
                DepartureDate = schedule.DepartureDate,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime
            };

            return Ok(dto);
        }


        //POST a train schedule
        [HttpPost]
        public IActionResult Create([FromBody] AddTrainScheduleRequestDto trainScheduleRequestDto)
        {
            var schedule = new TrainSchedule
            {
                TrainId = trainScheduleRequestDto.TrainId,
                FromStationId = trainScheduleRequestDto.FromStationId,
                ToStationId = trainScheduleRequestDto.ToStationId,
                DepartureDate = trainScheduleRequestDto.DepartureDate,
                DepartureTime = trainScheduleRequestDto.DepartureTime,
                ArrivalTime = trainScheduleRequestDto.ArrivalTime
            };
            dbContext.Scedules.Add(schedule);
            dbContext.SaveChanges();

            var dto = new TrainScheduleDto
            {
                Id = schedule.Id,
                TrainId = schedule.TrainId,
                FromStationId = schedule.FromStationId,
                ToStationId = schedule.ToStationId,
                DepartureDate = schedule.DepartureDate,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime
            };
            return CreatedAtAction(nameof(GetById), new { id = schedule.Id }, dto);
        }


        //PUT to update a schedule
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateTrainScheduleRequestDto updateTrainScheduleRequestDto)
        {
            var schedule = dbContext.Scedules.FirstOrDefault(s => s.Id == id);

            if (schedule == null)
                return NotFound();

            schedule.TrainId = updateTrainScheduleRequestDto.TrainId;
            schedule.FromStationId = updateTrainScheduleRequestDto.FromStationId;
            schedule.ToStationId = updateTrainScheduleRequestDto.ToStationId;
            schedule.DepartureDate = updateTrainScheduleRequestDto.DepartureDate;
            schedule.DepartureTime = updateTrainScheduleRequestDto.DepartureTime;
            schedule.ArrivalTime = updateTrainScheduleRequestDto.ArrivalTime;

            dbContext.SaveChanges();

            var trainScheduleDto = new TrainScheduleDto
            {
                TrainId = schedule.TrainId,
                FromStationId = schedule.FromStationId,
                ToStationId = schedule.ToStationId,
                DepartureDate = schedule.DepartureDate,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
            };

            return Ok(trainScheduleDto);
        }


        //DELETE a trainSchedule

        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult Delete([FromRoute] Guid id)
        {
            var schedule = dbContext.Scedules.FirstOrDefault(s => s.Id == id);

            if (schedule == null)
                return NotFound();

            dbContext.Scedules.Remove(schedule);
            dbContext.SaveChanges();

            return NoContent();
        }



    }
}
