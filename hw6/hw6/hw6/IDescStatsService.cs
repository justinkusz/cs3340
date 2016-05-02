using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace hw6
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDescStatsService" in both code and config file together.
    [ServiceContract]
    public interface IDescStatsService
    {
        [OperationContract]
        DescriptiveStatistics GetDescStats(double[] input);
    }

    [DataContract]
    public class DescriptiveStatistics{
        int sampleSize;
        double average;
        double stDeviation;
    }
}
