using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeShop.Application.DTO.Category
{
    public class CategoryDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string CategoryName { get; set; }
    }
}
