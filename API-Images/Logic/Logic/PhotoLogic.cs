using Data;
using Entities.Entities;
using Entities.SearchFilter;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class PhotoLogic : IPhotoLogic
    {
        private readonly ServiceContext _serviceContext;
        public PhotoLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public async Task DeletePhoto(int id)
        {
            var photoToDelete = await _serviceContext.Set<PhotoItem>()
            .Where(u => u.Id == id).FirstAsync();

            photoToDelete.IsActive = false;

            await _serviceContext.SaveChangesAsync();
        }

        public async Task<List<PhotoItem>> GetAllPhotos()
        {
            return await _serviceContext.Set<PhotoItem>().ToListAsync();
        }

        public async Task<PhotoItem> GetPhotoById(int id)
        {
            return await _serviceContext.Set<PhotoItem>()
                    .Where(u => u.Id == id).FirstAsync();

        }

        public async Task<List<PhotoItem>> GetPhotosByFilter(PhotoFilter photoFilter)
        {
            var resultList = _serviceContext.Set<PhotoItem>()
                        .Where(u => u.IsActive == true);

            if (photoFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > photoFilter.InsertDateFrom);
            }

            if (photoFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < photoFilter.InsertDateTo);
            }

            return await resultList.ToListAsync();
        }

        public async Task<int> InsertPhotoAPI(PhotoItem photoItem)
        {
            _serviceContext.Photos.Add(photoItem);
            await _serviceContext.SaveChangesAsync();
            return photoItem.Id;
        }

        public async Task<int> InsertPhotoFront(PhotoItem photoItem)
        {
            _serviceContext.Photos.Add(photoItem);
            await _serviceContext.SaveChangesAsync();
            return photoItem.Id;
        }

        public async Task UpdatePhotoAPI(PhotoItem photoItem)
        {
            _serviceContext.Photos.Update(photoItem);
            await _serviceContext.SaveChangesAsync();
        }

        public async Task UpdatePhotoFront(PhotoItem photoItem)
        {
            _serviceContext.Photos.Update(photoItem);
            await _serviceContext.SaveChangesAsync();
        }
    }
}
