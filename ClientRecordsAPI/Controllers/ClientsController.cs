using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClientRecordsAPI.Data;
using ClientRecordsAPI.Models;
using AutoMapper;
using ClientRecordsAPI.DTOs;

namespace ClientRecordsAPI.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClientsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ClientDto>), 200)]
        [ProducesResponseType(typeof(ClientDto), 201)]
        public IActionResult GetAllClients()
        {
            var clients = _context.Clients.ToList();
            var clientDtos = _mapper.Map<List<ClientDto>>(clients);
            return Ok(clientDtos);
        }


        [HttpPost]
        [ProducesResponseType(typeof(List<ClientDto>), 200)]
        [ProducesResponseType(typeof(ClientDto), 201)]
        public IActionResult CreateClient(CreateClientDto createDto)
        {
            var client = _mapper.Map<Client>(createDto);
            _context.Clients.Add(client);
            _context.SaveChanges();

            var clientDto = _mapper.Map<ClientDto>(client);
            return CreatedAtAction(nameof(GetAllClients), new { id = clientDto.Id }, clientDto);
        }        
    }
}
