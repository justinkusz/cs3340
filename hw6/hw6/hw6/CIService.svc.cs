using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace hw6
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CIService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CIService.svc or CIService.svc.cs at the Solution Explorer and start debugging.
    public class CIService : ICIService
    {
        public ConfidenceInterval GetCI(double[] input)
        {
            ConfidenceInterval result = new ConfidenceInterval();

            return result;
        }
    }
}
