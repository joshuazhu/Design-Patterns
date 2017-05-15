using System;
using System.Collections.Generic;
using System.Text;
using BuilderPattern;
using TemplateMethodPattern;

namespace MediatorPattern
{
    public interface IMediator
    {
        List<IColleague> ColleagueList { get; set; }

        void DistributeMessage(IColleague sender, string message);

        void Register(IColleague colleague);
    }

    public class ConcreteMediator : IMediator
    {
        public ConcreteMediator()
        {
            ColleagueList = new List<IColleague>();
        }

        public void Register(IColleague colleague)
        {
            ColleagueList.Add(colleague);
        }

        public List<IColleague> ColleagueList { get; set; }

        public void DistributeMessage(IColleague sender, string message)
        {
            foreach (IColleague c in ColleagueList)
                if (c != sender)
                {
                    c.ReceiveMessage(message);
                }
        }
    }

    public class ConcreteColleague : IColleague
    {
        private string Name;

        public ConcreteColleague(string name)
        {
            Name = name;
        }

        public void SendMessage(IMediator mediator, string message)
        {
            mediator.DistributeMessage(this, message);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine(Name + " received " + message.ToString());
        }
    }

    public interface IColleague
    {
        void SendMessage(IMediator mediator, string message);

        void ReceiveMessage(string message);
    }

    public class MediatorPatternRunner : IPatterRunner
    {
        public void RunPattern()
        {
            var ColleagueA = new ConcreteColleague("A");
            var ColleagueB = new ConcreteColleague("B");
            var ColleagueC = new ConcreteColleague("C");
            var ColleagueD = new ConcreteColleague("D");

            var mediator1 = new ConcreteMediator();
            mediator1.Register(ColleagueA);
            mediator1.Register(ColleagueB);
            mediator1.Register(ColleagueC);

            ColleagueA.SendMessage(mediator1, "MessageX from ColleagueA");

            var mediator2 = new ConcreteMediator();
            mediator2.Register(ColleagueB);
            mediator2.Register(ColleagueD);

            ColleagueB.SendMessage(mediator2, "MessageX from ColleagueA");
        }
    }
}
