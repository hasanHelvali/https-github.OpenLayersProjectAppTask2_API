using BasarSoftTask2_API.DTOs;
using BasarSoftTask2_API.Entities;
using BasarSoftTask2_API.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasarSoftTask2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
            //private readonly IRepository<LocationAndUser> _repository;
            private readonly IMapRepository<LocAndUsers> _repository;

            //public MapsController(IRepository<LocationAndUser> repository)
            public MapsController(IMapRepository<LocAndUsers> repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public async Task<IActionResult> ListLocation()
            {
                var values = await _repository.GetAllAsync();
                return Ok(values);
            }

            [HttpGet("LocationById/{id}")]
            public async Task<IActionResult> LocationById(int id)
            {
                var value = await _repository.GetByIdAsync(id);
                return Ok(value);
            }


            [HttpPost]
            public async Task<IActionResult> CreateMap(LocAndUserDTO locAndUser)
            {
                await _repository.CreateAsync(new LocAndUsers { });
                return Ok();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var value = await _repository.GetByIdAsync(id);
                await _repository.RemoveAsync(value);
                return Ok();
            }

        }
    }
