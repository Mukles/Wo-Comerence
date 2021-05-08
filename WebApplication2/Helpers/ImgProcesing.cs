using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Helpers
{
    public class ImgProcesing
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public ImgProcesing(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public string ImageProcesing(IFormFile file)
        {
            string Folder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
            string fileName = new Guid().ToString() + "_" + file.FileName;
            string filepath = Path.Combine(Folder, fileName);
            using(var fileStream = new FileStream(filepath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            
            return fileName;
        }
    }
}
