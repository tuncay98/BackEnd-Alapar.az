using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlApar.az.Model
{
    public class DataBaseForHome
    {
        public List<Agent> Agentler { get; set; }

        public List<Ad> Elanler { get; set; }

        public List<Ad> TamSiyahi { get; set; }

        public List<Ad> VipElanlar { get; set; }

        public List<Image> Sekiller { get; set; }
    }
}