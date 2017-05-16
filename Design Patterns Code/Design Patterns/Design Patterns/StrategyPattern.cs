using System;
using System.Collections.Generic;
using System.Text;
using TemplateMethodPattern;

namespace StrategyPattern
{
    public interface IStrategy
    {
        void operate();
    }

    public class Strategy1 : IStrategy
    {

        public void operate()
        {
            Console.WriteLine("operate 1");
        }
    }

    public class Strategy2 : IStrategy
    {

        public void operate()
        {
            Console.WriteLine("operate 2");
        }
    }

    public class Context
    {
        private IStrategy Strategy { get; set; }

        public Context(IStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public void operate()
        {
            this.Strategy.operate();
        }
    }

    public class ProxyPatternRunner : IPatterRunner
    {
        public void RunPattern()
        {
            var context1 = new Context(new Strategy1());
            context1.operate();

            var context2 = new Context(new Strategy2());
            context2.operate();
        }
    }
}
