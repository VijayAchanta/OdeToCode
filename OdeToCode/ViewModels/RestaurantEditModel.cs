﻿using OdeToCode.Models;
using System.ComponentModel.DataAnnotations;

namespace OdeToCode.ViewModels
{
    public class RestaurantEditModel
    {
        [Required,MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
