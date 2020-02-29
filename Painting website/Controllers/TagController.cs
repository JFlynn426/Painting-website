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
    public class TagController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TagController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Picture>>> GetAll()
        {
            var results = _context.Pictures
                  .Include(i => i.Location)
                  .Include(i => i.Tag).OrderBy(Picture => Picture.Tag);
            return await results.ToListAsync();
        }
    }
}
