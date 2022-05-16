using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AsyncCallbackService
{
    
    public class AsyncComplexCalc : AsyncComplexCalculator
    {
        public AsyncComplexNumber AddComplex(AsyncComplexNumber number1, AsyncComplexNumber number2)
        {
            var a = new AsyncComplexNumber();
            a.RealValue = number1.RealValue + number2.RealValue;
            a.ImaginaryValue = number1.ImaginaryValue + number2.ImaginaryValue; ;
            return a;
        }

        public AsyncComplexNumber MultipleComplex(AsyncComplexNumber number1, AsyncComplexNumber number2)
        {
            throw new NotImplementedException();
        }
    }
}
