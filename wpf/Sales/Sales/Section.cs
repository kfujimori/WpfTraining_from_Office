using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales
{
    class Section
    {

        public string Title{get; set;}
        public byte Id { get; set; }



        public override int GetHashCode() {return Id;}
        public override string ToString() { return Title; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            int a = GetHashCode();
            int b = obj.GetHashCode();
            return a==b;
        }

        static public bool operator ==(Section a, Section b)
        {
            if ((object)a == null) return ((object)b == null);
            return a.Equals(b);
        }
        static public bool operator !=(Section a, Section b)
        {
            if ((object)a == null) return !((object)b == null);
            return !a.Equals(b);
        }
    }
}
