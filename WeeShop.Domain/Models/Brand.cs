using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Domain.CommonFields;

namespace WeeShop.Domain.Models
{
    public class Brand : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Established_Year  { get; set; }
    }
}
