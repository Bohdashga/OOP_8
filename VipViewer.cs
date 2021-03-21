using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_8
{
    public class VipViewer : Viewer
    {
        public string Name { get; set; }
        public int Rating { get; set; }

        public VipViewer() : base()
        {
            Name = "";
            Rating = 0;
        }

        public VipViewer(string Name, string Movie, Time StartTime, int Rating = 0) : base(Movie, StartTime)
        {
            this.Name = Name;
            this.Rating = Rating;
        }

        public VipViewer(VipViewer vipViewer) : base(vipViewer)
        {
            Name = vipViewer.Name;
            Rating = vipViewer.Rating;
        }

        public override bool Equals(object obj)
        {
            var viewer = obj as VipViewer;

            if (viewer == null)
                return false;

            if (viewer == this)
                return true;

            return Name == viewer.Name && Movie == viewer.Movie && StartTime.Equals(viewer.StartTime) &&
                Rating == viewer.Rating;
        }
    }
}
