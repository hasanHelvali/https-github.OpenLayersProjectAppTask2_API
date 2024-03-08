using BasarSoftTask2_API.DTOs;
using BasarSoftTask2_API.Entities;
using BasarSoftTask2_API.IRepository;
using BasarSoftTask2_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Implementation;
using NetTopologySuite.IO;
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
            var _values = await _repository.GetAllAsync();
            var values = _values.Select(x => new LocAndUserDTO
            {
                ID = x.ID,
                WKT=x.Geometry.ToText(),
                Name = x.Name,
                Type = x.Type,
            }).ToList();

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
            var geometry = GeometryAndWktConvert.WktToGeometrys(locAndUser.WKT);
            await _repository.CreateAsync(new LocAndUsers
            {
                Name = locAndUser.Name,
                Type = locAndUser.Type,
                Geometry = geometry
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(value);
            return Ok();
        }









        //NtsGeometryServices  => NtsGeometryServices = new NtsGeometryServices(CoordinateArraySequenceFactory.Instance, new PrecisionModel(), _DefaultSrid);

//GeometryFactory = NtsGeometryServices.CreateGeometryFactory();

        //public static Geometry WktToGeometry(string _wkt)
        //{
        //    WKTReader wKTReader = new WKTReader(GeometryTool.Instance.NtsGeometryServices)
        //    {
        //        IsOldNtsCoordinateSyntaxAllowed = false
        //    };
        //    return wKTReader.Read(_wkt);
        //}
        //NtsGeometryServices = new NtsGeometryServices(CoordinateArraySequenceFactory.Instance, new PrecisionModel(), _DefaultSrid);

        //GeometryFactory = NtsGeometryServices.CreateGeometryFactory();

    }
}
