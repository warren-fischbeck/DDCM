using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.XML.Core
{
    class Skills
    {
        public string Name { get; set; }
        public Attribute Attribute { get; set; }
        public int Modifier { get; set; }
        public bool Expertise { get; set; }
        public bool Proficent { get; set; }
    }
}
