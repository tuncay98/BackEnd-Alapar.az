using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlApar.az.Model
{
    public class DataBaseForAddingAds
    {
        public List<City> Seherler { get; set; }
        public List<Region> Rayonlar { get; set; }
        public List<Village> Qesebeler { get; set; }
        public List<Category> Kategoriyalar { get; set; }
        public List<RoomCount> OtaqSaylari { get; set; }
        public List<BuildingType> Bina_Novu { get; set; }

        
    }
}