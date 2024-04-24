using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Domain.CommonFields;

namespace WeeShop.Domain.Models
{
    public class Category : BaseModel
    {
        [Required (ErrorMessage ="Name is Required")]
        [StringLength(50,ErrorMessage ="CategoryName can't be Longer than 50 Characters")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
