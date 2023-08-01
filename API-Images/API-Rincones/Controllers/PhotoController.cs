using API.Enums;
using API_Rincones.IService;
using Entities.Entities;
using Entities.SearchFilter;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Web.Http.Cors;

namespace API_Rincones.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class PhotoController : ControllerBase
    {
        private readonly ILogger<PhotoController> _logger;
        private readonly IPhotoServices _photoServices;
        public PhotoController(ILogger<PhotoController> logger, IPhotoServices photoServices)
        {
            _logger = logger;
            _photoServices = photoServices;
        }

        [HttpPost(Name = "InsertPhotoAPI")]
        [ActionName("InsertPhotoAPI")]
        public async Task<int> InsertPhoto([FromForm] PhotoUploadModel photoUploadModel)
        {

            var photoItem = new PhotoItem
            {
                Id = 0,
                Title = photoUploadModel.Title,
                Description = photoUploadModel.Description,
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                FileExtension = photoUploadModel.FileExtension,
                IsActive = true,
            };

            // Convert the image content to a byte array
            
                using (var stream = new MemoryStream())
                {
                    await photoUploadModel.File.CopyToAsync(stream);
                    byte[] bytes = stream.ToArray();
                    photoItem.Content = Convert.ToBase64String(bytes);
                }
            

            return await _photoServices.InsertPhotoAPI(photoItem);
        }


        [HttpPost(Name = "InsertPhotoFront")]
        [ActionName("InsertPhotoFront")]
        public async Task<int> InsertPhoto([FromBody] PhotoFromFront photoFromFront)
        {

            return await _photoServices.InsertPhotoFront(photoFromFront);

        }


        [HttpGet(Name = "GetAllPhotos")]
        public async Task<List<PhotoItem>> GetAllPhotos()
        {
            return await _photoServices.GetAllPhotos();
        }

        [HttpGet(Name = "GetPhotosById")]
        public async Task<PhotoItem> GetPhotosById(int id)
        {
            return await _photoServices.GetPhotoById(id);
        }

        [HttpGet(Name = "GetPhotosByFilter")]
        public async Task<List<PhotoItem>> GetPhotosByFilter([FromQuery] PhotoFilter photoFilter)
        {
            return await _photoServices.GetPhotosByFilter(photoFilter);
        }

        [HttpPatch(Name = "UpdatePhotoAPI")]
        [ActionName("UpdatePhotoAPI")]
        public async Task Patch(int id, [FromForm] PhotoUploadModel photoUploadModel)
        {
            var photoItem = await _photoServices.GetPhotoById(id);

            photoItem.Title = photoUploadModel.Title;
            photoItem.Description = photoUploadModel.Description;
            photoItem.IsActive = true;
            photoItem.UpdateDate = DateTime.Now;
            if (photoUploadModel.File != null)
            {
                photoItem.FileExtension = (FileExtensionEnum)Enum.Parse(typeof(FileExtensionEnum), Path.GetExtension(photoUploadModel.File.FileName).Substring(1), true);
                using (var stream = new MemoryStream())
                {
                    await photoUploadModel.File.CopyToAsync(stream);
                    byte[] bytes = stream.ToArray();
                    photoItem.Content = Convert.ToBase64String(bytes);
                }

            }

            await _photoServices.UpdatePhotoAPI(photoItem);
        }

        [HttpPatch(Name = "UpdatePhotoFront")]
        [ActionName("UpdatePhotoFront")]
 

        public async Task Patch([FromBody] PhotoItem photoItem)
        {
            await _photoServices.UpdatePhotoFront(photoItem);
        }

        [HttpDelete(Name = "DeletePhoto")]
        public async Task Delete([FromQuery] int id)
        {
            await _photoServices.DeletePhoto(id);
        }
    }
}
