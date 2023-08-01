using API.Enums;
using Microsoft.AspNetCore.Http;


namespace Entities.Entities
{
    public class PhotoUploadModel
    {
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; private set; }
        public bool IsActive { get; private set; }
        public FileExtensionEnum FileExtension { get; set; }
    }
}
