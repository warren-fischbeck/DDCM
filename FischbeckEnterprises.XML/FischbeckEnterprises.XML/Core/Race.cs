using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.XML.Core
{
    partial class Race : Feature
    {
        public RacialFeature RacialFeatures { get; set; }
    }
    partial class RacialBonus
    {
        public Attribute Attribute { get; set; }
        public int Bonus { get; set; }
    }

    partial class RacialFeature : Feature
    {
        public List<RacialBonus> AttributeBonus { get; set; }
    }
}
