using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp2.Model
{
    public class Item
    {
        public int Id { get; set; }
        public int IdTask { get; set; }
        public string ItemName { get; set; }
        public string ItemDetails { get; set; }
        public string Status { get; set; }
    }
}
