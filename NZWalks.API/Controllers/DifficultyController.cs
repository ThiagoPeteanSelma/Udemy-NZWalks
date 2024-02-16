using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDifficultyRepositoy difficultyRepositoy;

        public DifficultyController(IMapper mapper, IDifficultyRepositoy difficultyRepositoy)
        {
            this.mapper = mapper;
            this.difficultyRepositoy = difficultyRepositoy;


        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var difficultiesModel = await difficultyRepositoy.GetAllAsync();
            return Ok(mapper.Map<List<DifficultyDTO>>(difficultiesModel));
        }
    }
}
