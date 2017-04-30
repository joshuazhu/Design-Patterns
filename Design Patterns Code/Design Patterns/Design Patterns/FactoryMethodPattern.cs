using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern
{
    public abstract class BMW
    {
        public string CarName { get; set; }
    }

    public class BMW320 : BMW
    {
        public BMW320()
        {
            this.CarName = "BMW320";
        }
    }

    public class BMW532 : BMW
    {
        public BMW532()
        {
            this.CarName = "BMW532";
        }
    }

    public interface FactoryBMW
    {
        BMW CreateBMW();
    }

    public class FactoryBMW320 : FactoryBMW
    {
        public BMW CreateBMW()
        {
            return new BMW320();
        }
    }

    public class FactoryBMW532 : FactoryBMW
    {
        public BMW CreateBMW()
        {
            return new BMW532();
        }
    }

  /*  public class FactoryMethodPattern
    {
        public static void Main()
        {
            var factoryBMW320 = new FactoryBMW320();
            var bmw3 = factoryBMW320.CreateBMW();

            var factoryBMW532= new FactoryBMW532();
            var bmw5 = factoryBMW532.CreateBMW();
        }
    }*/
}
