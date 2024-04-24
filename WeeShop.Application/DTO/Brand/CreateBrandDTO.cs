﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeShop.Application.DTO.Brand
{
    public class CreateBrandDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Established_Year { get; set; }
    }
}
