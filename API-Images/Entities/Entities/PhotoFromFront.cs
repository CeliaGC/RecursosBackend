using API.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PhotoFromFront
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public FileExtensionEnum FileExtension { get; set; }

        public PhotoItem ToPhotoItem()
        {
            var photoItem = new PhotoItem();

                photoItem.Title = Title;
                photoItem.Description = Description;
                photoItem.Content = Content;
                photoItem.IsActive = IsActive;
                photoItem.FileExtension = FileExtension;
                photoItem.UpdateDate = UpdateDate;
                photoItem.InsertDate = InsertDate;

                return photoItem;


        }
        
    }
}
