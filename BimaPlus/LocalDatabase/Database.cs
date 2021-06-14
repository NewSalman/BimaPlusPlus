using System;
using System.Collections.Generic;
using System.Text;

namespace BimaPlus.LocalDatabase
{
    class Database
    {
        string Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "User.db3";

        public Database()
        {

        }
    }
}
