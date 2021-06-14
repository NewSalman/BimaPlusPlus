using BimaPlus.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BimaPlus.LocalDatabase.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Balance { get; set; }
        public string PhoneNumber { get; set; }
        public string ExpiredAt { get; set; }
        public string CardType { get; set; }

        public Social Social { get; set; }
        public Package Package { get; set; }
    }
}
