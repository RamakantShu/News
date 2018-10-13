using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using webapi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using webapi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize]
    //[ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminRepository _adminRepository;
        
        //private IHostingEnvironment _hostingEnvironment;
        
        //public AdminController(IHostingEnvironment hostingEnvironment, IAdminRepository adminRepository)
        public AdminController(IAdminRepository adminRepository)
        {
            //this._hostingEnvironment = hostingEnvironment;
            this._adminRepository = adminRepository;            
        }
        
        //[Route("/PropertyDDL")]
        [HttpGet("PropertyDDL/{ppcode}"), DisableRequestSizeLimit]
        public async Task<List<PropertyModel>> GetPropertyDdlById(string ppcode = "")
        {
            var result=await _adminRepository.GetPropertyListByParentPropertyCode(ppcode);
            return result;
        }

        // [HttpGet(""), DisableRequestSizeLimit]
        // public async Task<Dictionary<string,string>> Get()
        // {
        //     var result=await _adminRepository.GetPropertyByParentPropertyCode("NewsCategory");
        //     return result;
        // }

        // POST api/values
        [HttpPost, DisableRequestSizeLimit]
        public async Task<string> Post([FromForm] NewsContentModels mdl)
        { 
            string result="Something went wrong.";
            try
            {                
                IFormFileCollection files = Request.Form.Files;
                int res = await _adminRepository.SaveNewsContent(mdl, files);
                // string folderName = "Upload";
                // string webRootPath = _hostingEnvironment.WebRootPath;
                // string newPath = Path.Combine(webRootPath, folderName);
                // if (!Directory.Exists(newPath))
                // {
                //     Directory.CreateDirectory(newPath);
                // }
                // if (file.Length > 0)
                // {
                //     string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                //     string fullPath = Path.Combine(newPath, fileName);
                //     using (var stream = new FileStream(fullPath, FileMode.Create))
                //     {
                //         file.CopyTo(stream);
                //     }
                //     result="Content uploaded successfully!!";
                // }
                return result ;
            }
            catch (System.Exception ex)
            {
                return result + "\n" + ex.Message;
            }
            //return CreatedAtAction("GetUser", new { id = user.Id }, user);
            //return result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
