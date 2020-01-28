using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entity.Entity
{
    public class Trademark
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}