using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitor
{
    public class NumberGen
    {
        //Variables that hold the patient data (from the random number methods)
        public int heart1, breath1, systolic1, diastolic1, temp1;

        //Method that creates the patients heart rate
        public int Heart1()
        {
            Random rnd = new Random();
            heart1 = rnd.Next(75, 85);
            return heart1;
        }

        //Method that creates the patients breathing rate
        public int Breath1()
        {
            Random rnd = new Random();
            breath1 = rnd.Next(14, 18);
            return breath1;
        }

        //Method that creates the patients systolic rate
        public int Systolic1()
        {
            Random rnd = new Random();
            systolic1 = rnd.Next(110, 120);
            return systolic1;
        }

        //Method that creates the patients diastolic rate
        public int Diastolic1()
        {
            Random rnd = new Random();
            diastolic1 = rnd.Next(65, 75);
            return diastolic1;
        }

        //Method that creates the patients temperature
        public int Temp1()
        {
            Random rnd = new Random();
            temp1 = rnd.Next(35, 38);
            return temp1;
        }

    }
}
