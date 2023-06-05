using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task5._2
{
    class Program
    {
        public static void Main(string[] args)
        {
            FitnessCenter fitnessCenter = new FitnessCenter();

            fitnessCenter.Records.Add(new Record { ClientID = 1, Year = 2022, Month = 1, Duration = 5 });
            fitnessCenter.Records.Add(new Record { ClientID = 1, Year = 2022, Month = 2, Duration = 3 });
            fitnessCenter.Records.Add(new Record { ClientID = 2, Year = 2022, Month = 1, Duration = 7 });
C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\Microsoft.Build.Framework.dll            fitnessCenter.Records.Add(new Record { ClientID = 2, Year = 2022, Month = 2, Duration = 4 });
            fitnessCenter.Records.Add(new Record { ClientID = 2, Year = 2022, Month = 3, Duration = 6 });
            fitnessCenter.Records.Add(new Record { ClientID = 3, Year = 2022, Month = 1, Duration = 8 });

            fitnessCenter.FindClientWithMaxDuration();

            Console.ReadKey();

        }
    }
}
