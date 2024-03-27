using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environment_Monitoring_System_Interface
{
    public class Sensor
    {
        public List<double> temps;
        public List<double> hums;
        public double bat;
        public double holdTemp;
        public double holdHum;
        public int esm;
        public double minTemp = -5;
        public double maxTemp = 100;
        public double minHum = -5;
        public double maxHum = 100;
        public List<double> tempAvg;
        public List<double> humAvg;
        public double dayTemp;
        public double dayHum;
        public int num;
        public bool tempScale;
        public string name;
        public bool inequality;
        public bool quantity;
        public bool breachTemp = false;
        public bool breachHum = false;
        public bool standbyTemp = true;
        public bool standbyHum = true;
        
        public Sensor(int i)
        {
            num = i;
            name = "Sensor " + i;

            temps = new List<double>();
            hums = new List<double>();
            tempAvg = new List<double>();
            humAvg = new List<double>();
        }

        public void addData(string[] transmitData, bool scale)
        {
            holdTemp = Convert.ToDouble(transmitData[1]) / 100;
            holdHum = Convert.ToDouble(transmitData[2]) / 100;
            bat = Convert.ToDouble(transmitData[3]) / 100;
            esm = Convert.ToInt16(transmitData[4]);
            tempScale = scale;

            if (scale)
            {
                holdTemp = (holdTemp - 32) * 5 / 9;
            }

            temps.Add(holdTemp);
            hums.Add(holdHum);
        }

        public void setThresh(double min, double max, bool which)
        {
           if (which)
            {
                minHum = min;
                maxHum = max;
                standbyHum = false;
            }
           else
            {
                minTemp = min;
                maxTemp = max;
                standbyTemp = false;
            }
        }

        public void takeAvg()
        {
            tempAvg.Add(temps.Average(x => x));
            humAvg.Add(hums.Average(x => x));

            temps.Clear();
            hums.Clear();
        }

        public double dailyTempAvg()
        {
            dayTemp = tempAvg.Average(x => x);

            tempAvg.Clear();

            return dayTemp;
        }

        public double dailyHumAvg()
        {
            dayHum = humAvg.Average(x => x);

            humAvg.Clear();

            return dayHum;
        }

        public void checkTemp()
        {
            if (holdTemp < minTemp)
            {
                breachTemp = true;
                inequality = false;
            }
            else if (holdTemp > maxTemp)
            {
                breachTemp = true;
                inequality = true;
            }
            else
                breachTemp = false;
        }

        public void checkHum()
        {
            if (holdHum < minHum)
            {
                breachHum = true;
                inequality = false;
            }
            else if (holdHum > maxHum)
            {
                breachHum = true;
                inequality = true;
            }
            else
                breachHum = false;
        }
    }
}
