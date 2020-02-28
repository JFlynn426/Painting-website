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
    public class CategoryViewController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CategoryViewController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("{Category}")]
        public async Task<ActionResult<List<Picture>>> Get([FromRoute] string Category)
        {
            var results = _context.Pictures.Include(i => i.Location)
                  .Include(i => i.Tag).Where(Picture => Picture.Location.Place.ToLower() == Category.ToLower());
            return await results.ToListAsync();
        }
    }
}
