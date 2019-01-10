using Distance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BusinessLogic
{
   public class DistanceConverter
    {
        public static DistanceTable ModelToEntity (DistanceModel model)
        {
            DistanceTable dis = new DistanceTable();
            dis.destination = model.Destination;
            dis.distance = model.Distance;
            dis.hits = model.Hits;
            dis.source = model.Source;
            dis.id = model.Id;
            return dis;
        }

        public static DistanceModel EntityToModel(DistanceTable entity)
        {
            DistanceModel model = new DistanceModel();
            model.Destination=entity.destination;
            model.Distance=entity.distance;
            model.Hits=entity.hits;
            model.Source=entity.source;
            model.Id = entity.id;
            return model;
        }
    }
}
