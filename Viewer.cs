using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_8
{
    public class Viewer : ISerializable
    {
        public string Movie { get; set; }
        public Time StartTime { get; set; }

        public Viewer()
        {
            Movie = "";
            StartTime = new Time();
        }

        public Viewer(string Movie, Time StartTime)
        {
            this.Movie = Movie;
            this.StartTime = new Time(StartTime);
        }

        public Viewer(Viewer viewer)
        {
            Movie = viewer.Movie;
            StartTime = new Time(viewer.StartTime);
        }


        public override string ToString()
        {
            return "Movie: " + Movie +
                "\nStart time: " + StartTime;
        }

        public string objectToString()
        {
            return Movie + ";" + StartTime.objectToString();
        }
        public void stringToObject(string str)
        {
            string[] values = str.Split(';');
            Movie = values[0];
            StartTime.Hours = int.Parse(values[1]);
            StartTime.Minutes = int.Parse(values[2]);
        }
    }
}
