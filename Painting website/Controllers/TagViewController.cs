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
    public class TagViewController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TagViewController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("{Tag}")]
        public async Task<ActionResult<List<Picture>>> Get([FromRoute] string Tag)
        {
            var results = _context.Pictures.Include(i => i.Location)
                  .Include(i => i.Tag).Where(Picture => Picture.Tag.Tags.ToLower() == Tag.ToLower());
            return await results.ToListAsync();
        }
    }
}
