using Entities.Entities;
using Entities.SearchFilter;

namespace API_Rincones.IService
{
    public interface IPhotoServices
    {
        Task<int> InsertPhotoAPI(PhotoItem photoItem);
        Task<int> InsertPhotoFront(PhotoFromFront photoFromFront);
        Task UpdatePhotoFront(PhotoItem photoItem);
        Task UpdatePhotoAPI(PhotoItem photoItem);
        Task DeletePhoto(int id);
        Task<List<PhotoItem>> GetAllPhotos();
        Task<PhotoItem> GetPhotoById(int id);
        Task<List<PhotoItem>> GetPhotosByFilter(PhotoFilter photoFilter);
    }
}
