using AutoMapper;
using Contracts;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineAPI.Presentation.Controllers
{
    [Route("api/ticket/[action]")]
    [ApiController]
    public class TicketController:ControllerBase
    {


        private readonly IRepositoryManegar _repository;
        private readonly IMapper _mapper;

        public TicketController(IRepositoryManegar repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetTicketById")]
        public IActionResult GetTicketById(int Id)
        {
            var Ticket = _repository.Teket.GetUTicketById(Id);
            if (Ticket == null)
            {
                return NotFound($"there is no Ticket with id{Id}");
            }
            else
            {
                var TicketDTO = _mapper.Map<TicketDto>(Ticket);

                return Ok(TicketDTO);
            }
        }



        [HttpPost(Name = "CreateTicket")]
        public IActionResult CreateTicket([FromBody] CreateTicketDto ticket)
        {
            ArgumentNullException.ThrowIfNull(ticket);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            

                var TicketEntity = _mapper.Map<Ticket>(ticket);
                _repository.Teket.CreateTicket(TicketEntity);
                _repository.Save();
                var TicketToReturn = _mapper.Map<TicketDto>(TicketEntity);
                return CreatedAtRoute("GetTicketById", new { id = TicketToReturn.Id }, TicketToReturn);
            
            
        }

        [HttpPut(Name = "ScanTicket")]
        public IActionResult ScanTicket([FromBody] UpdateTicketDto ticket, int ticketId)
        {
            //take "true or false in body" true for scanned
            var SelectedTicket = _repository.Teket.GetUTicketById(ticketId);
            ArgumentNullException.ThrowIfNull(SelectedTicket);
            var ticketEntity = _mapper.Map(ticket, SelectedTicket);
            _repository.Teket.UpdateTicket(ticketEntity);
            _repository.Save();
            return Ok($"the Ticket with id {ticketId} has been Scanned successfully");
        }


        [HttpGet(Name = "CheckIfScannOrNot")]
        public IActionResult CheckIfScannOrNot(int ticketId)
        {
            var Ticket = _repository.Teket.GetUTicketById(ticketId);
            if (Ticket == null)
            {
                return NotFound($"there is no Ticket with id{ticketId}");
            }
            else
            {
                var TicketDTO = _mapper.Map<CheckIfScannOrNotDto>(Ticket);
                if (TicketDTO.ScanedOrNot == true)
                    return Ok($"tiket  with id {Ticket.Id}of UserId{Ticket.UserId} Scanneded");
                else
                    return BadRequest($"tiket  with id {Ticket.Id} of UserId {Ticket.UserId} Not Scanneded!!");

                return Ok(TicketDTO);
            }
        }


    }
}
