using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance_Tracker
{
    internal class Operations
    {
        //grade check for regular
        public string gradecheckforRegular(double AvgMark)
        {
            string gradeLetter;

            if (AvgMark >= 90)
                gradeLetter = "A+";
            else if (AvgMark >= 80)
                gradeLetter = "A";
            else if (AvgMark >= 70)
                gradeLetter = "B+";
            else if (AvgMark >= 60)
                gradeLetter = "B";
            else if (AvgMark >= 50)
                gradeLetter = "C";
            else
                gradeLetter = "F";

            switch (gradeLetter)
            {
                case "A+":
                    return "A+";
                case "A":
                    return "A";
                case "B+":
                    return "B+";
                case "B":
                    return "B";
                case "C":
                    return "C";
                default:
                    return "F";
            }
        }

        //grade check for exchange
        public string gradecheckforExchange(double AvgMark)
        {
            if(AvgMark >= 60)
            {
                return "Pass";
            }
            else
            {
                return "Fail";
            }
        }

    }
}
