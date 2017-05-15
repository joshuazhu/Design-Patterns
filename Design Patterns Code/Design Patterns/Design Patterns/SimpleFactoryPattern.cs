using System;
using System.Collections.Generic;
using System.Text;
using BuilderPattern;
using TemplateMethodPattern;

namespace SimpleFactoryPattern
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

    public class SimpleFactoryPattern
    {
        public BMW createBMW(int type)
        {
            switch (type)
            {
                case 3:
                    return new BMW320();
                case 5:
                    return new BMW532();
                default:
                    return new BMW320();
            }
        }
    }

    public class SimpleFactoryPatternRunner : IPatterRunner
    {
        public void RunPattern()
        {
            var factory = new SimpleFactoryPattern();
            var bmw3 = factory.createBMW(3);
            var bmw5 = factory.createBMW(5);
        }
    }
}
