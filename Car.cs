using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geographical_information_system
{
    internal class Car
    {

        private string carlicenseplate;
        private string cartype;
        private string from;    
        private string to;
        private PointLatLng location;

        public Car(string carlicenseplate, string cartype, string from, string to, PointLatLng location)
        {
            this.Carlicenseplate = carlicenseplate;
            this.Cartype = cartype;
            this.From = from;
            this.To = to;
            this.Location = location;
        }

        public string Carlicenseplate { get => carlicenseplate; set => carlicenseplate = value; }
        public string Cartype { get => cartype; set => cartype = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public PointLatLng Location { get => location; set => location = value; }

        public override string ToString()
        {
            string str = "\n" + Carlicenseplate + "\n " + Cartype + "\n From: " + From + "\n To: " + To;
            return str;
        }
    }
}
