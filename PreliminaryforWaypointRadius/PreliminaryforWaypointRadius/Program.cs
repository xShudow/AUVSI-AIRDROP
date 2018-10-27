using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreliminaryforWaypointRadius
{
    class Calculations
    {
        //variable labels, defining data type
        double cruiseSpeed;
        double timedelay;
        double parachuteTime;
        double crossArea;
        double Weight;

        //static variables, only change based on location
        double rho0 = 0.00231636; //airdensity sealevel in slugs4
        double dt = 0.01; //increament time, seconds

        public void DefineVariable()
        {
            //
            cruiseSpeed = ;
            parachuteTime = ;
            timedelay = ;
            crossArea = ;
            Weight = ;
        
        }

        public double radiusWaypoint()
        {
            double v2radius = cruiseSpeed;
            double m = Weight / 32.2;

            double crossDrag = cd * rho0 / 2.0 * crossArea * v2radius * v2radius;
            double t_radius = 0.00;
            double radius = 0.00
;
            double changeinradius = radius + v2radius * delaytime;

            while (t_radius < parachuteTime)
            {
                radius = radius + v2radius * dt;
                v2radius = v2radius - (crossDrag / m) * dt;
                crossDrag = cd * rho0 / 2.0 * crossArea * v2radius * v2radius;
                t_radius = t_radius + dt;
            }
            radius = Math.Round(radius, 2);
            return radius;
        }
    }
}
