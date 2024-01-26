using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route256.Contest
{
    public static class DoctorAppointment
    {
        public static void Main()
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var nm = Console.ReadLine().Split().Select(x => Convert.ToInt32(x)).ToArray();
                int windowsCount = nm[0];
                int pacientsCount = nm[1];
                var windows = Console.ReadLine().Split().Select(x => Convert.ToInt32(x)).ToArray();
                var windowsDic = new Dictionary<int, int>();
                for (int j = 0; j < windowsCount; j++)
                {
                    
                }
            }
        }
    }
}
