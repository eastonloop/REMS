using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environment_Monitoring_System_Interface
{
    internal class Sensor
    {
        public List<double> temps;
        public List<double> hums;
        public double bat;
        public double holdTemp;
        public double holdHum;
        public int esm;
        public bool scale = false;

        public void addData(string[] incoming)
        {
            holdTemp = Convert.ToDouble(incoming[1]) / 100;
            holdHum = Convert.ToDouble(incoming[2]) / 100;
            bat = Convert.ToDouble(incoming[3]) / 100;
            esm = Convert.ToInt16(incoming[4]);

            if (scale)
            {
                holdTemp = (holdTemp - 32) * 5 / 9;
            }
            
           // temps.Add(holdTemp);
           // hums.Add(holdHum);
        }
    }
}
