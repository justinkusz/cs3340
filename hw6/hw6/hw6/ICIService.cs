using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace hw6
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICIService" in both code and config file together.
    [ServiceContract]
    public interface ICIService
    {
        [OperationContract]
        ConfidenceInterval GetCI(double[] input);
    }

    [DataContract]
    public class ConfidenceInterval
    {
        double LCL;
        double UCL;
    }
}
