using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entity.Entity.ViewModel
{
    public class ProductViewModel
    {

        [Key]
        public int Id { get; set; }

        [StringLength(200), Required(ErrorMessage = "Bu alan doldurulmalıdır"), DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [StringLength(200), Required(ErrorMessage = "Bu alan doldurulmalıdır"), DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }

        [DataType(DataType.DateTime), Required(ErrorMessage = "Bu alan doldurulmalıdır"), DisplayName("Tarih")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Bu alan doldurulmalıdır"), DisplayName("Ürün Miktarı")]
        public int Amount { get; set; }

        [Required]
        public int Trademark { get; set; }

        public string ImagePath { get; set; }

        public List<HttpPostedFileBase> PictureUpload { get; set; }
    }
}
