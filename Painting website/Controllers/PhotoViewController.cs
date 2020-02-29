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
    public class PhotoViewController : Controller
    {
        private readonly DatabaseContext _context;

        public PhotoViewController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Picture>> Get([FromRoute] int id)
        {
            var results = _context.Pictures.Where(Picture => Picture.Id == id);
            return Ok(results);
        }

    }
}
