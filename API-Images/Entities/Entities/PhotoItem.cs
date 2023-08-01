using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Enums;
using Microsoft.AspNetCore.Http;

namespace Entities.Entities
{
    public class PhotoItem
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public byte[] Content { get; set; }
        //public Stream Content { get; set; }

        public string Content { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public FileExtensionEnum FileExtension { get; set; }

    }
}
