using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;
using Painting_website.Models;

namespace Painting_website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CatsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Cats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllCats()
        {
            return await _context.Place.ToListAsync();
        }
    }
}
