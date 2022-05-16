using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AsyncCallbackService
{
    
    public class AsyncComplexCalc : IAsyncComplexCalculator
    {
        IComplexCallback callback = null;

        public AsyncComplexCalc()
        {
            callback = OperationContext.Current.GetCallbackChannel<IComplexCallback>();
        }

        public void AddComplex(AsyncComplexNumber number1, AsyncComplexNumber number2)
        {
            var a = new AsyncComplexNumber();
            a.RealValue = number1.RealValue + number2.RealValue;
            a.ImaginaryValue = number1.ImaginaryValue + number2.ImaginaryValue; ;
            callback.CalculationResult("add", a);
        }

        public void MultipleComplex(AsyncComplexNumber number1, AsyncComplexNumber number2)
        {
            var result = new AsyncComplexNumber();
            result.RealValue = number1.RealValue * number2.RealValue - number1.ImaginaryValue * number2.ImaginaryValue;
            result.ImaginaryValue = number1.RealValue * number2.ImaginaryValue + number1.ImaginaryValue * number2.RealValue;
            callback.CalculationResult("multi", result);
        }
    }
}
