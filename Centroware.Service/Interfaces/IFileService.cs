using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
   public interface IFileService
    {
        Task<string> SaveFile(IFormFile file, String folderName);
    }
}
