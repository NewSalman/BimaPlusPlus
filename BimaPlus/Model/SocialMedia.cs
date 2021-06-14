using System;
using System.Collections.Generic;
using System.Text;

namespace BimaPlus.Model
{
    public class Social
    {
        public string FacebookEmail { get; set; }
        public string MicrosoftEmail { get; set; }
        public string GoogleEmail { get; set; }

        public bool GoogleSync { get; set; }
        public bool FacebookSync { get; set; }
        public bool MicrosoftSync { get; set; }
    }
}
