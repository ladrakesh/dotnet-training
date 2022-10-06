﻿namespace DotNetTraining_Assignments4.Models.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
    }
}
