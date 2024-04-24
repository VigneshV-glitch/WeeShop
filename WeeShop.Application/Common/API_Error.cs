using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeShop.Application.Common
{
    public class API_Error
    {
        public string Description { get; set; }

        public API_Error(string description)
        {
            Description = description;
        }
    }
}
