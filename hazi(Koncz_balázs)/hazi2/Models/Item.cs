using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hazi2.Models
{
    public class Item
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ItemNumber { get; set; }
        public string BarCode { get; set; }
        public string Piece { get; set; }
    }
}