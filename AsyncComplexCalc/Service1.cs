using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AsyncCallbackService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : AsyncComplexCalculator
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public AsyncComplexNumber GetDataUsingDataContract(AsyncComplexNumber composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
