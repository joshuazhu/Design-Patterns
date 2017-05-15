using System;
using BuilderPattern;
using TemplateMethodPattern;

namespace PrototypePattern
{
    public abstract class IPrototype
    {
        public string Id { set; get; }
        public abstract IPrototype Copy();
    }

    public class ConcretePrototype : IPrototype
    {
        public ConcretePrototype(string id)
        {
            Id = id;
        }

        public override IPrototype Copy()
        {
            return (IPrototype)this.MemberwiseClone();
        }
    }

    public class PrototypePatternRunner : IPatterRunner
    {
        public void RunPattern()
        {
            var prototype = new ConcretePrototype("1");
            var clone = prototype.Copy();
            Console.WriteLine("Clone: {0}", clone.Id);
            Console.ReadLine();
        }
    }
}
