using Distance;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _02_BusinessLogic
{
  public  class DistanceLogic
    {
        protected DistanceEntities DB = new DistanceEntities();

        static void Main(string[] args)
        {
        }

        public double GetDistance(string source, string destination)
        {
            double distance = GetExistsDistance(source, destination);
            if (distance != -1) //if the specific place not exists in the db
                return distance;

            distance= GetDistanceByGoogleMaps(source, destination);
            if (distance == -1)
                return -1;

            DistanceModel dis = new DistanceModel();
            dis.Destination = destination;
            dis.Source = source;
            dis.Hits = 1;
            dis.Distance = distance;
            CreateDistance(dis);

            return distance;
        }

        public double GetExistsDistance(string source, string destination)
        {
            DistanceTable distance = DB.DistanceTables.FirstOrDefault(d => d.source == source && d.destination == destination);
            if (distance != null)
            {
                DB.DistanceTables.Attach(distance);
                distance.hits++;
                DB.SaveChanges();
                return distance.distance;
            }
                return -1;
        }

        public DistanceModel GetPopularDistances()
        {
            DistanceTable popular = DB.DistanceTables.OrderByDescending(d => d.hits).FirstOrDefault();
            DistanceModel model = DistanceConverter.EntityToModel(popular);
            //List<DistanceTable> popList = DB.DistanceTables.OrderByDescending(d => d.hits).Take(10).ToList();
            return model;
        }

        public void CreateDistance(DistanceModel model)
        {

           DistanceTable distance = DistanceConverter.ModelToEntity(model);
            DB.DistanceTables.Add(new DistanceTable
            {
                source = distance.source,
                destination = distance.destination,
                distance = distance.distance,
                hits = 1
            });
            DB.SaveChanges();
        }

        public double GetDistanceByGoogleMaps(string source, string destination)
        {
            try
            {
                string url = @"https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + source + "&destinations=d" + destination + "&key=AIzaSyCjHqDFEysAJ136tyulCPeNGklwEVHgA08 ";

                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                StreamReader reader = new StreamReader(data);
                // json-formatted string from maps api
                string responseFromServer = reader.ReadToEnd();
                dynamic jsonObj = JObject.Parse(responseFromServer);
                string status = jsonObj["rows"][0]["elements"][0]["status"];
                if (status != "OK")
                    return -1;
                string distance = jsonObj["rows"][0]["elements"][0]["distance"].text;
                double dis = double.Parse(distance.Split(' ')[0]);
                response.Close();

                return dis;
            }
            catch(Exception ex)
            {
                throw new Exception("Unrecognized address");
            }
        
        }


        public void Dispose()
        {
            DB.Dispose();
        }

    }
}
