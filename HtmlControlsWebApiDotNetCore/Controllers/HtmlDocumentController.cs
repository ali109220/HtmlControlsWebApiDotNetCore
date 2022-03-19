using HtmlControlsWebApiDotNetCore.Data;
using HtmlControlsWebApiDotNetCore.Dto;
using HtmlControlsWebApiDotNetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlControlsWebApiDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HtmlDocumentController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public HtmlDocumentController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext applicationDbContext
            )
        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetHtmlDocuments()
        {
            var username = HttpContext.Items["Username"].ToString();
            var user =await _userManager.FindByNameAsync(username);
            var all = _applicationDbContext.HtmlDocuments.Where(x=> x.UserId == user.Id).ToList();
            return Ok(new { Status = "Success", Data = all });
        }
       // [Authorize]
        [HttpPost]
        [Route("UploadAsHml")]
        public async Task<IActionResult> UploadAsHml([FromBody] HtmlDocmentContentInputDto input)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "tmp");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "sample.html")))
            {
                await outputFile.WriteAsync(input.HtmlContent);
            }
            return Ok(new { Status = "Success", Data = "sample.html" });
        }
        [HttpPost]
        [Route("DownloadAsHml")]
        public async Task<IActionResult> DownloadAsHml()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "tmp");
            var memory = new MemoryStream();
            using (var stream = new FileStream(Path.Combine(path, "sample.html"), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(Path.Combine(path, "sample.html"));
            return File(memory, contentType, fileName);
        }
        [Authorize]
        [HttpGet]
        [Route("GetOne")]
        public async Task<IActionResult> GetHtmlDocument(int id)
        {
            HtmlDocument doc = await _applicationDbContext.HtmlDocuments.Where(x => x.Id == id).Include(x => x.HtmlControls.OrderBy(x=> x.ElementOrder)).FirstOrDefaultAsync();
            if (doc == null)
            {
                return NotFound();
            }
            return Ok(new { Status = "Success", Data = doc });
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutHtmlDocument(HtmlDocmentInputDto htmlDocument)
        {
            HtmlDocument doc = await _applicationDbContext.HtmlDocuments.Where(x => x.Id == htmlDocument.Id).Include(x => x.HtmlControls).FirstOrDefaultAsync();
            //db.Entry(customer).State = EntityState.Modified;
            doc.Name = htmlDocument.Name;
            doc.HtmlControls = doc.HtmlControls.Where(hc => htmlDocument.HtmlControls.Any(hcm => hcm.Id != 0 && hcm.Id == hc.Id)).ToList();
            foreach (var control in htmlDocument.HtmlControls)
            {
                var htmlControl = control.Id != 0 ? doc.HtmlControls.FirstOrDefault(x=> x.Id == control.Id): new HtmlControl();
                htmlControl.Align = control.Align;
                htmlControl.BackgroundColor = control.BackgroundColor;
                htmlControl.ButtonColor = control.ButtonColor;
                htmlControl.ButtonType = control.ButtonType;
                htmlControl.ElementId = control.ElementId;
                htmlControl.ElementOrder = control.ElementOrder;
                htmlControl.ElementType = control.ElementType;
                htmlControl.FontColor = control.FontColor;
                htmlControl.FontSize = control.FontSize;
                htmlControl.Height = control.Height;
                htmlControl.HtmlText = control.HtmlText;
                htmlControl.Link = control.Link;
                htmlControl.MarginBottom = control.MarginBottom;
                htmlControl.MarginLeft = control.MarginLeft;
                htmlControl.MarginTop = control.MarginTop;
                htmlControl.MarginRight = control.MarginRight;
                htmlControl.Text = control.Text;
                htmlControl.Width = control.Width;
                htmlControl.HtmlDocument = doc;
                if(control.Id == 0)
                   doc.HtmlControls.Add(htmlControl);
            }
            try
            {
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HtmlDocExists(htmlDocument.Id))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new GeneralResponseDto { Status = "Failed", Message = "there an Error" });
                }
            }

            return Ok(new GeneralResponseDto { Status = "Success", Message = "Html document created successfully!" });

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostHtmlDocument([FromBody] HtmlDocmentInputDto model)
        {
            var username = HttpContext.Items["Username"].ToString();
            var user = await _userManager.FindByNameAsync(username);
            var htmlDocument = new HtmlDocument();
            htmlDocument.Name = model.Name;
            htmlDocument.UserId = user.Id;
            foreach (var control in model.HtmlControls)
            {
                var htmlControl = new HtmlControl();
                htmlControl.Align = control.Align;
                htmlControl.BackgroundColor = control.BackgroundColor;
                htmlControl.ButtonColor = control.ButtonColor;
                htmlControl.ButtonType = control.ButtonType;
                htmlControl.ElementId = control.ElementId;
                htmlControl.ElementOrder = control.ElementOrder;
                htmlControl.ElementType = control.ElementType;
                htmlControl.FontColor = control.FontColor;
                htmlControl.FontSize = control.FontSize;
                htmlControl.Height = control.Height;
                htmlControl.HtmlText = control.HtmlText;
                htmlControl.Link = control.Link;
                htmlControl.MarginBottom = control.MarginBottom;
                htmlControl.MarginLeft = control.MarginLeft;
                htmlControl.MarginTop = control.MarginTop;
                htmlControl.MarginRight = control.MarginRight;
                htmlControl.Text = control.Text;
                htmlControl.Width = control.Width;
                htmlControl.HtmlDocument = htmlDocument;
                htmlDocument.HtmlControls.Add(htmlControl);
            }
            await _applicationDbContext.HtmlDocuments.AddAsync(htmlDocument);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(new { Status = "Success", Data = htmlDocument.Id });
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteHtmlDocument(int id)
        {
            HtmlDocument doc = await _applicationDbContext.HtmlDocuments.FindAsync(id);
            if (doc == null)
            {
                return NotFound();
            }
            _applicationDbContext.HtmlDocuments.Remove(doc);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(new GeneralResponseDto { Status = "Success", Message = "Html document deleted successfully!" });
        }
        private bool HtmlDocExists(int id)
        {
            return _applicationDbContext.HtmlDocuments.Count(e => e.Id == id) > 0;
        }

    }
}
