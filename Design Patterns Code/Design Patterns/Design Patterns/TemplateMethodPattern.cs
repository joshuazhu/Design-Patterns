using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodPattern
{
    //Abstract Class
    public abstract class AbstractClass
    {
        //basic methods
        protected abstract void SimpleMethod1();

        protected abstract void SimpleMethod2();

        //template methods
        public void templateMethod()
        {
            SimpleMethod1();
            SimpleMethod2();
        }
    }

    //Concrete methods
    public class ConcreteClass : AbstractClass
    {

        protected override void SimpleMethod1()
        {
            Console.WriteLine("method1");
        }

        protected override void SimpleMethod2()
        {
            Console.WriteLine("method2");
        }
    }

    public class TemplateMethodPatternRunner : IPatterRunner
    {
        public void RunPattern()
        {
            ConcreteClass class1 = new ConcreteClass();
            class1.templateMethod();
        }
    }
}
