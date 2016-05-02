using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace hw6
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DescStatsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DescStatsService.svc or DescStatsService.svc.cs at the Solution Explorer and start debugging.
    public class DescStatsService : IDescStatsService
    {
        public DescriptiveStatistics GetDescStats(double[] input)
        {
            int size = input.Length;
            double average = 0.0;

            for (int i = 0; i < input.Length; i++)
            {
                average += input[i];
            }

            average = average / size;

            double stDeviation = 0.0;

            for (int i = 0; i < input.Length; i++)
            {
                stDeviation += Math.Pow(input[i], 2.0);
            }
            stDeviation = Math.Sqrt(stDeviation / (size - 1));
            return new DescriptiveStatistics(size, average, stDeviation);
        }
    }
}
