using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.ImageUtilities;
using MasterReview.ImageUtilities;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;
using Painting_website.Models;

namespace Painting_website.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private IImageWriter imagewriter;

        public ImageController(IImageWriter writer)
        {
            this.imagewriter = writer;
        }

        [HttpPost]

        public async Task<ActionResult> ImageUpload(IFormFile file)
        {
            var filepath = await imagewriter.UploadImage(file);
            var results = new CloudinaryHelper().UploadFile(filepath);
            return Ok(results);
        }
    }
}
