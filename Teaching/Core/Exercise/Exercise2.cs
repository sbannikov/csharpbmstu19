using System;
using System.ServiceModel;

namespace Bmstu.IU6.Teaching.Exercise
{
    class Complex
    {
        public double Re;
        public double Im;
        public double Module()
        {
            return Re * Re + Im * Im;
        }
    }
    [ServiceContract()]
    interface IExercise2
    {
        [OperationContract()]
        Complex Add(Complex a, Complex b);
        Complex Sub(Complex a, Complex b);
    }

    [ServiceBehavior
     (InstanceContextMode = InstanceContextMode.Single,
      ConcurrencyMode = ConcurrencyMode.Reentrant)]
    class Exercise2 : IExercise2
    {
        public Complex Add(Complex a, Complex b)
        {
            return new Complex()
            {
                Re = a.Re + b.Re,
                Im = a.Im + b.Im
            };
        }
        public Complex Sub(Complex a, Complex b)
        {
            return new Complex()
            {
                Re = a.Re - b.Re,
                Im = a.Im - b.Im
            };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host;
            host = new ServiceHost(typeof(Exercise2));
            host.Open();
            Console.WriteLine("Сервис запущен");
            Console.ReadLine();
        }
    }
}
