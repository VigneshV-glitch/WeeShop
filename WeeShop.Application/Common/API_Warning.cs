using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeShop.Application.Common
{
    public class API_Warning
    {
        public string Description { get; set; }

        public API_Warning(string description)
        {
            Description = description;
        }
    }
}
