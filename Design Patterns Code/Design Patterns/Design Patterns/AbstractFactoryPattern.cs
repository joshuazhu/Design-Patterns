using System;
using System.Collections.Generic;
using System.Text;
using BuilderPattern;
using TemplateMethodPattern;

namespace AbstractFactoryPattern
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

    public abstract class aircondition
    {
        public string ConditionName { get; set; }
    }
    public class AirConditionBMW320 : aircondition
    {
        public AirConditionBMW320()
        {
            this.ConditionName = "BMW320 AC";
        }
    }
    public class AirConditionBMW532 : aircondition
    {
        public AirConditionBMW532()
        {
            this.ConditionName = "BMW532 AC";
        }
    }


    public interface FactoryBMW
    {
        BMW createBMW();
        aircondition createAirC();
    }

    public class FactoryBMW320 : FactoryBMW
    {
        public BMW createBMW()
        {
            return new BMW320();
        }
        public aircondition createAirC()
        {
            return new AirConditionBMW320();
        }
    }

    public class FactoryBMW523 : FactoryBMW
    {
        public BMW createBMW()
        {
            return new BMW532();
        }
        public aircondition createAirC()
        {
            return new AirConditionBMW532();
        }
    }

    public class AbstractFactoryRunner : IPatterRunner
    {
        public void RunPattern()
        {
            var factoryBMW320 = new FactoryBMW320();
            var bmw320 = factoryBMW320.createBMW();
            var bmw320Ac = factoryBMW320.createAirC();
        }
    }
}
