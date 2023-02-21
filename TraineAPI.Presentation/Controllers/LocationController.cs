using AutoMapper;
using Contracts;
using Entites;
using Entites.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/Location/[action]")]
    public class LocationController:ControllerBase
    {

        private readonly IRepositoryManegar _repository;
        private readonly IMapper _mapper;

        public LocationController(IRepositoryManegar repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetLocationById")]
        public IActionResult GetLocationById(int id)
        {
            var location =_repository.Location.GetLocationById(id);
            if (location == null)
                return NotFound("There is no location match!");
            else
            {
                var LocationDto=_mapper.Map<locationDto>(location);
                return Ok(LocationDto);
            }
        }


        [HttpGet(Name = "GetLocationByTrainNum")]
        public IActionResult GetLocationByTrainNum(int TrainNum)
        {
            //Train train = _repository.Train.GetTrainById(TrainNum);
            //if (train == null)
            //    return NotFound("TrainNumber You Have Enter not Exist");

            //var AllSharedLocationForSelected=_repository.Location.GetAllSharedLocationForSelectedTrain(TrainNum);
           
            return Ok();

            
        }



            [HttpPost (Name ="ShareLocation")]
        public IActionResult ShareLocation([FromBody] ShareLocationDto location )
        {
            ArgumentNullException.ThrowIfNull(location);
            if(! ModelState.IsValid)
                return UnprocessableEntity(location);

            Ticket ticket = _repository.Teket.CheckTecketExiesting((int)location.TicketNumber);
            Train train = _repository.Train.GetTrainById((int)location.TrainNumber);

            if(ticket == null)
                return NotFound("TicketNumber You Have Enter not Exist");

            if (train == null)
                return NotFound("TrainNumber You Have Enter not Exist");

           
                var LocationEntity = _mapper.Map<Location>(location);
                _repository.Location.ShareLocation(LocationEntity);
                _repository.Save();
                var LocationToReturn = _mapper.Map<locationDto>(LocationEntity);
                return CreatedAtRoute("GetLocationById", new { id = LocationToReturn.Id }, LocationToReturn);
            
            
        }



        [HttpPut(Name = "RefreshLocation")]
        public IActionResult RefreshLocation([FromBody] UpdateLocationDto location)
        {

            var SelectedLocation = _repository.Location.findlatestlocationBYTicket((int)location.TicketNumber);
            ArgumentNullException.ThrowIfNull(SelectedLocation);
            if(!ModelState.IsValid)
                return UnprocessableEntity(location);

            

            Ticket ticket = _repository.Teket.CheckTecketExiesting((int)location.TicketNumber);
            Train train = _repository.Train.GetTrainById((int)location.TrainNumber);

            if (ticket == null)
                return NotFound("TicketNumber You Have Enter not Exist");

            if (train == null)
                return NotFound("TrainNumber You Have Enter not Exist");

            var LocationEntity = _mapper.Map(location, SelectedLocation);
            _repository.Location.RefreshLocation(LocationEntity);
            _repository.Save();
            return Ok($"the Location Refresh successfully");
        }


    }
}
