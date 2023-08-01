using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.RequestModels
{
    internal class NewPhotoRequest
    {
        public Guid IdWeb { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCliente { get; set; }

        public int IdProducto { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
        public decimal Descuento { get; private set; }
        public decimal ImporteTotal { get; private set; }

        public DateTime FechaEntrega { get; set; }
        public bool Pagado { get; set; }
        public bool Entregado { get; set; }
        public bool IsActive { get; set; }

        public PhotoItem ToPhotoItem()
        {
            var photoItem = new PhotoItem();
            photoItem.Id = 0;
            photoItem.Name = photoUploadModel.File.FileName;
            photoItem.InsertDate = DateTime.Now;
            photoItem.UpdateDate = DateTime.Now;
            photoItem.FileExtension = photoUploadModel.FileExtension;
        }
    }
}
