using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PickPoint.DataBase;
using PickPoint.Models;
using PickPoint.Models.DTO;
using PickPoint.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PickPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostamatController : Controller
    {
        private readonly PickPointContext _context;
        public PostamatController(PickPointContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<PostamatDTO>> GetAll()
        {
            var postamats = _context.Postamats.Where(x => x.Status).Select(x => Mapper.Map<Postamat, PostamatDTO>(x)).ToList();
            if (!postamats.Any())
                return NotFound();
            return postamats;
        }

        [HttpGet("{number}")]
        public ActionResult<PostamatDTO> Get(string number)
        {
            if (Validate.IsBadPostamatNumber(number))
                return BadRequest();
            var postamat = _context.Postamats.Find(number);
            if (postamat == null)
                return NotFound();
            else 
                return Mapper.Map<Postamat, PostamatDTO>(postamat);
        }
    }
}
