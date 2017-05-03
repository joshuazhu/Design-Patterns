using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern
{
    public interface ITarget
    {
        void MethodA();
    }

    public class Client
    {
        private ITarget _iTarget { set; get; }

        public Client(ITarget target)
        {
            _iTarget = target;
        }

        public void Request()
        {
            _iTarget.MethodA();
        }

    }

    public class Adaptee
    {
        public void MethodB()
        {
            Console.WriteLine("Adaptee's MethodB called");
        }
    }

    public class Adapter : ITarget
    {
        Adaptee _adaptee = new Adaptee();

        public void MethodA()
        {
            _adaptee.MethodB();
        }

        public static void Main()
        {
            var adapter = new Adapter();
            var client = new Client(adapter);
            client.Request();
        }
    }
}