using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeShop.Domain.CommonFields
{
    public class BaseModel

        /* This file Contains Common (or) Repeated Field Properties from Two Or more Models(Tables)
         For the Code Reuseability, Inherite this Class where you want add the Common Fields*/
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
