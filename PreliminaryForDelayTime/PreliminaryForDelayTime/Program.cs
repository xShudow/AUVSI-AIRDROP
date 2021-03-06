using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreliminaryForDelayTime
{
    class Calculations
    {
        //variable labels, defining data type
        double delay;
        double altitude;
        double v_terminal;
        double v0;
        double Weight;
        double Area;
        double CD;
        double diameter;
        double diameter_feet;
        double diameter_inch;

        //static variables, only change based on location
        double rho0 = 0.00231636; // air density sealevel in slugs
        double g = 32.2; // gravity acceleration is ft/s^2
        double dt = 0.01; // increament time, seconds

        //*DEFINING VARIABLE VALUES HERE*
        public void DefineVariable()
        {
            //parachute numbers
            diameter_feet = 3; //ft
            diameter_inch = 11; //in
            diameter = diameter_feet+diameter_inch/12; //ft

            //variables for time1
            delay = 0;//seconds before parachute can open
            altitude = 60; // ft, airplane altitude from ground level

            //variables for time2
            v0 = -1 * delay * g; // ft/s, negative going down
            Weight = 2.68; // lbs
            Area = Math.PI*Math.Pow(((diameter*2)/(2*Math.PI)),2); // ft^2
            CD = 1.7; // drag coefficient of parachute
            v_terminal = -Math.Sqrt((Weight*2)/(CD*rho0*Area)); // ft/s, negative going down
        }

        //myactualfuckingfunctionfortime1, in other words>yourfuckingdelaytime
        public object Time1()
        {
            //assuming drag force on UGV is negligble 
            double alt = altitude;
            alt = alt - g / 2 * delay * delay;
            if (alt <= 0)
            {
                string x = "ERROR FOR HEIGHT CHECK, DELAY CANNOT BE USED";
                return x;
            }
            else
            {
                return delay;
            }
        }

        //myactualfuckingfunctionfortime2
        public object Time2()
        {
            double v = v0;
            double m = Weight / 32.2;
            double t2 = 0;

            double alt = altitude;
            alt = alt - g / 2 * delay * delay;

            double Drag = CD * rho0 / 2 * Area * v * v;
            if (v > v_terminal)
            {
                while (v > (v_terminal * 0.98))
                {
                    alt = alt + v * dt;
                    v = v + (Drag / m - g) * dt;
                    Drag = CD * rho0 / 2 * Area * v * v;
                    t2 = t2 + dt;
                }
            }
            else
            {
                while (v < (v_terminal * 1.02))
                {
                    alt = alt + v * dt;
                    v = v + (Drag / m - g) * dt;
                    Drag = CD * rho0 / 2 * Area * v * v;
                    t2 = t2 + dt;
                }
            }

            if (alt <= 0)
            {
                string x = "ERROR FOR HEIGHT CHECK, DELAY CANNOT BE USED";
                return x;
            }
            else
            {
                t2 = Math.Round(t2, 2);
                return t2;
            }

        }

        //myactualfuckingfunctionfortime3, in other words>your terminalvelocity descend time
        public double Time3()
        {
            //altitude after t1, altitude after t2, subtract those altitude from default altitude to get altitude 3, divide by terminal velocity to get t3
            double alt = altitude;
            //altitude change after delaytime
            alt = alt - g / 2 * delay * delay;

            //altitude change after dragtime
            double v = v0;
            double m = Weight / 32.2;
            double t2 = 0;

            double Drag = CD * rho0 / 2 * Area * v * v;

            if (v > v_terminal)
            {
                while (v > (v_terminal * 0.98))
                {
                    alt = alt + v * dt;
                    v = v + (Drag / m - g) * dt;
                    Drag = CD * rho0 / 2 * Area * v * v;
                    t2 = t2 + dt;
                }
            }
            else
            {
                while (v < (v_terminal * 1.02))
                {
                    alt = alt + v * dt;
                    v = v + (Drag / m - g) * dt;
                    Drag = CD * rho0 / 2 * Area * v * v;
                    t2 = t2 + dt;
                }
            }
            double t3 = -alt / v_terminal;
            t3 = Math.Round(t3, 2);
            return t3;
        }

        public void Display()
        {
            Console.WriteLine("DelayTime: {0}", Time1());
            Console.WriteLine("DragTime: {0}", Time2());
            Console.WriteLine("TerminalTime: {0}", Time3());
            Console.WriteLine("TerminalTime: {0}", diameter);
        }

    }
    class ExecuteCalculations
    {
        static void Main(string[] args)
        {
            Calculations r = new Calculations();
            r.DefineVariable();
            r.Display();
            Console.ReadLine();
        }
    }
}
