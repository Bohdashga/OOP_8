using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_8
{
    interface ISerializable
    {
        string objectToString();
        void stringToObject(string str);
    }
}
