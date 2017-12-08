using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestTask.Controllers
{
    public class WebApiController : ApiController
    {
        public class Emploe
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string LastName { get; set; }
            public string Sex { get; set; }
            public int PositionId { get; set; }
            public int DepartmentId { get; set; }
        }
        public class Indicator
        {
            public string id { get; set; }
            public string title { get; set; }
            public double value { get; set; }
            public double minValue { get; set; }
            public double maxValue { get; set; }
            public double mass { get; set; }
        }
        [HttpPost]
        public void Insert (Emploe emploe)
        {
            using (var db = new DBEntities())
            {
                db.Employers.Add(new Employers() { FirstName = emploe.FirstName, SecondName = emploe.SecondName, LastName = emploe.LastName, Sex = emploe.Sex == "Male", PositionId = emploe.PositionId, DepartmentId = emploe.DepartmentId });
            }
        }

        [HttpPost]
        public IEnumerable<Indicator> Get()
        {
            var list = new List<Indicator>();
            //list.Add(new Indicator() { id = "0", mass = 400, minValue = 40, maxValue = 360, title = "Бла бла 1", value = 380 });//красн
            //list.Add(new Indicator() { id = "1", mass = 800, minValue = 60, maxValue = 700, title = "Бла бла 2", value = 750 }); //красн
            //list.Add(new Indicator() { id = "2", mass = 300, minValue = 100, maxValue = 270, title = "Бла бла 3", value = 220 });
            //list.Add(new Indicator() { id = "3", mass = 100, minValue = 20, maxValue = 80, title = "Бла бла 4", value = 10 }); //красн
            //list.Add(new Indicator() { id = "4", mass = 1000, minValue = 150, maxValue = 900, title = "Бла бла 5", value = 700 });
            //list.Add(new Indicator() { id = "5", mass = 700, minValue = 40, maxValue = 650, title = "Бла бла 6", value = 380 });
            //list.Add(new Indicator() { id = "6", mass = 500, minValue = 40, maxValue = 400, title = "Бла бла 7", value = 20 }); // красн
            //list.Add(new Indicator() { id = "7", mass = 400, minValue = 40, maxValue = 400, title = "Бла бла 8", value = 380 });
            for (int i = 2; i < 10; i++)
            {
                list.Add(GetRandom(i.ToString()));
            }
            return list;
        }

        private Indicator GetRandom(string id)
        {
            var rand = new Random(int.Parse(id) * DateTime.Now.Second);
            var temp = new Indicator() { id = id, mass = 1000, minValue = rand.Next(0, 200), maxValue = rand.Next(800, 1000), title = "someTitle", value = rand.Next(0, 1000) };
            return temp;
        }
    }
}