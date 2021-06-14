using System;
using System.Collections.Generic;
using System.Text;

namespace BimaPlus.Model
{
    public class Quota
    {
        public string ID { get; set; }
        public string PackageName { get; set; }
        public string PackageCardTitle { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public float Rate { get; set; }
        public bool WishList { get; set; }
        public string QuotaType { get; set; }
        public string ImagePath { get; set; }
        public string PackageType { get; set; }
    }
}
