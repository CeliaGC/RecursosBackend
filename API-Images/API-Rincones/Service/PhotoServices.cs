using API_Rincones.IService;
using Entities.Entities;
using Entities.SearchFilter;
using Logic.ILogic;
using Logic.Logic;

namespace API_Rincones.Services
{
    public class PhotoServices : IPhotoServices
    {
        private readonly IPhotoLogic _photoLogic;

        public PhotoServices(IPhotoLogic photoLogic)
        {
            _photoLogic = photoLogic;
        }

        public async Task<int> InsertPhotoAPI(PhotoItem photoItem)
        {
            return await _photoLogic.InsertPhotoAPI(photoItem);
        }

        public async Task<int> InsertPhotoFront(PhotoFromFront photoFromFront)
        {
            var newPhotoItem = photoFromFront.ToPhotoItem();
            return await _photoLogic.InsertPhotoFront(newPhotoItem);
            //return await _photoLogic.InsertPhotoFront(photoItem);
        }

        public async Task<List<PhotoItem>> GetAllPhotos()
        {
            return await _photoLogic.GetAllPhotos();
        }

        public async Task<PhotoItem> GetPhotoById(int id)
        {
            return await _photoLogic.GetPhotoById(id);
        }

        public async Task<List<PhotoItem>> GetPhotosByFilter(PhotoFilter photoFilter)
        {
            return await _photoLogic.GetPhotosByFilter(photoFilter);
        }

        public async Task UpdatePhotoFront(PhotoItem photoItem)
        {
            await _photoLogic.UpdatePhotoFront(photoItem);
        }

        public async Task UpdatePhotoAPI(PhotoItem photoItem)
        {
            await _photoLogic.UpdatePhotoAPI(photoItem);
        }

        public async Task DeletePhoto(int id)
        {
            await _photoLogic.DeletePhoto(id);
        }
    }
}

