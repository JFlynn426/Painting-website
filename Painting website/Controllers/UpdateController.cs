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
    public class UpdateController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UpdateController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Picture>> Post([FromBody] Picture newPicture)
        {
            _context.Pictures.Add(newPicture);
            await _context.SaveChangesAsync();
            return newPicture;
        }
        [HttpGet]
        public async Task<ActionResult<List<Picture>>> GetAll()
        {
            var results = _context.Pictures
                  .Include(i => i.Location)
                  .Include(i => i.Tag);
            return await results.ToListAsync();
        }
        [HttpDelete("{id}")]
        public ActionResult<Picture> DeleteAction([FromRoute] int id)
        {
            var PicToRemove = _context.Pictures.FirstOrDefault(Picture => Picture.Id == id);
            _context.Pictures.Remove(PicToRemove);
            _context.SaveChanges();
            return PicToRemove;
        }
    }
}
