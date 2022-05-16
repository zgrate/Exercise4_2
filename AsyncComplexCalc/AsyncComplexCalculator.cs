using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AsyncCallbackService
{

    public interface IComplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void CalculationResult(string operation, AsyncComplexNumber result);
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IComplexCallback))]
    public interface AsyncComplexCalculator
    {

        [OperationContract]
        AsyncComplexNumber AddComplex(AsyncComplexNumber number1, AsyncComplexNumber number2);
        
        [OperationContract]
        AsyncComplexNumber MultipleComplex(AsyncComplexNumber number1, AsyncComplexNumber number2);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "AsyncComplexCalc.ContractType".
    [DataContract]
    public class AsyncComplexNumber
    {
        double real = 0;
        double imaginary = 0;

        [DataMember]
        public double RealValue
        {
            get { return real; }
            set { real = value; }
        }

        [DataMember]
        public double ImaginaryValue
        {
            get { return imaginary; }
            set { imaginary = value; }
        }
    }
}
