﻿namespace projetoLojaAsp.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public decimal ?price { get; set; }
    }
}
