﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ItemModelSelected
    {
        public int Id { get; set; }
        public int IdTask { get; set; }
        public string ItemName { get; set; }
        public string ItemDetails { get; set; }
        public string Status { get; set; }
    }
}
