using AutoMapper;
using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaMagicController : ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;
        public VillaMagicController(ApplicationDBContext dbContext, IMapper mapper)
        {
                _dbContext = dbContext;
                _mapper = mapper;
        }





        [HttpGet]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas() {

            //return Ok(VillaStore.villaList);
            //return Ok(await _dbContext.Villas.ToListAsync());

            IEnumerable<Villa> list = await _dbContext.Villas.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<Villa>>(list));


        }

        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            //var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);
            var villa = await _dbContext.Villas.FirstOrDefaultAsync(x => x.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            //return Ok(villa);
            return Ok(_mapper.Map<VillaDTO>(villa));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<VillaDTO>> CrearVilla([FromBody] VillaCreateDTO villaCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if (VillaStore.villaList.FirstOrDefault(x => x.Nombre.ToLower() == villaDto.Nombre.ToLower()) != null)
            if (await _dbContext.Villas.FirstOrDefaultAsync(x => x.Nombre.ToLower() == villaCreateDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("Existe", "La villa con este nombre ya existe");
                return BadRequest(ModelState);
            }
            if (villaCreateDto == null)
            {
                return BadRequest();
            }

            //villaCreateDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            //VillaStore.villaList.Add(villaCreateDto);

            //Villa modelo = new Villa()
            //{
            //    Nombre = villaCreateDto.Nombre,
            //    Detalle = villaCreateDto.Detalle,
            //    ImageUrl = villaCreateDto.ImageUrl,
            //    Ocupantes = villaCreateDto.Ocupantes,
            //    Tarifa = villaCreateDto.Tarifa,
            //    MetrosCuadrados = villaCreateDto.MetrosCuadrados,
            //    Amenidad = villaCreateDto.Amenidad,
            //    FechaCreacion=DateTime.Now,
            //    FechaActualizacion=DateTime.Now,
            //};

            Villa modelo =  _mapper.Map<Villa>(villaCreateDto);

            await _dbContext.Villas.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return CreatedAtRoute("GetVilla", new { id = modelo.Id }, modelo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }
            //var villa =  VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            var villa = await _dbContext.Villas.FirstOrDefaultAsync(v => v.Id == id);
            if (villa ==null)
            {
                return NotFound();
            }
            //VillaStore.villaList.Remove(villa);
            _dbContext.Villas.Remove(villa);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaUpdateDto)
        {
            if (villaUpdateDto == null || id!= villaUpdateDto.Id)
            {
                return BadRequest();
            }
            //var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            //villa.Nombre = villaUpdateDto.Nombre;
            //villa.Ocupantes = villaUpdateDto.Ocupantes;
            //villa.MetrosCuadrados=villaUpdateDto.MetrosCuadrados;

            //Villa modelo = new Villa()
            //{
            //    Nombre = villaUpdateDto.Nombre,
            //    Detalle = villaUpdateDto.Detalle,
            //    ImageUrl = villaUpdateDto.ImageUrl,
            //    Ocupantes = villaUpdateDto.Ocupantes,
            //    Tarifa = villaUpdateDto.Tarifa,
            //    MetrosCuadrados = villaUpdateDto.MetrosCuadrados,
            //    Amenidad = villaUpdateDto.Amenidad
            //};

            Villa modelo = _mapper.Map<Villa>(villaUpdateDto);

            _dbContext.Villas.Update(modelo);            
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
