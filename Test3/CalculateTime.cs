using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Test3
{   internal class CalculateTime
    {
        public static DateTime lastPlayTimeHours = DateTime.MinValue;
        public static DateTime lastPlayTimeDate = DateTime.MinValue;

        public static bool isStopped()
        {
            if(Status.playingStatus == false) {
               lastPlayTimeHours = DateTime.Now;
                return false;
            }

        }

        public virtual double CalcTime(int startTime, int endTime)
        {

            return startTime;
        }

    }
}
