using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    /*
     * Receiver 
     */
    public abstract class Receiver
    {
        public abstract void doSomeThing();
    }

    public class ConcreteReceiver1 : Receiver
    {
        public override void doSomeThing()
        {
            Console.WriteLine("do something 1");
        }
    }

    public class ConcreteReceiver2 : Receiver
    {
        public override void doSomeThing()
        {
            Console.WriteLine("do something 2");
        }
    }

    /*
     * Command
     */
    public abstract class Command
    {
        public Receiver Receiver { set; get; }
        public abstract void execute();
    }

    public class ConcreteCommand1 : Command
    {
        public ConcreteCommand1(Receiver _receiver)
        {
            Receiver = _receiver;
        }

        public override void execute()
        {
            Receiver.doSomeThing();
        }
    }

    public class ConcreteCommand2 : Command
    {
        public ConcreteCommand2(Receiver _receiver)
        {
            Receiver = _receiver;
        }

        public override void execute()
        {
            Receiver.doSomeThing();
        }
    }

    /*
     * Invoker
     */
    public class Invoker
    {
        private Command Command;

        public void SetCommand(Command _command)
        {
            Command = _command;
        }

        public void Action()
        {
            this.Command.execute();
        }
    }

    /*
     * Client
     */
    public class Client
    {
        public static void Main(String[] args)
        {
            var invoker = new Invoker();
            var receiver = new ConcreteReceiver1();
            var command = new ConcreteCommand1(receiver);
            invoker.SetCommand(command);
            invoker.Action();
        }
    }
}
