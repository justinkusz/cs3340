using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace hw6
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DataParserService : IDataParserService
    {
        public double[] ParseData(string data)
        {
            string[] numbers = data.Split(' ');

            double[] result = new double[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = Convert.ToDouble(numbers[i]);
            }
            return result;
        }

        public string toString()
        {
            string result = "";

            return result;
        }
    }
}
