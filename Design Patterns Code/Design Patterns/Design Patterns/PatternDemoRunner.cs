using System;
using System.Collections.Generic;
using System.Text;
using BuilderPattern;
using ProxyPattern;

namespace TemplateMethodPattern
{
    public interface IPatterRunner
    {
        void RunPattern();
    }

    public class RunnerConfig
    {
        private List<IPatterRunner> PattenRunnerList;

        public RunnerConfig()
        {
            PattenRunnerList = new List<IPatterRunner>();
        }

        public void Register(IPatterRunner patternRunner)
        {
            PattenRunnerList.Add(patternRunner);
        }

        public void ExecuteAllRunners()
        {
            foreach (var runner in this.PattenRunnerList)
            {
                runner.RunPattern();
            }
        }

        public static void Main()
        {
            var config = new RunnerConfig();
            config.Register(new ProxyPatternRunner());
            config.ExecuteAllRunners();
            Console.ReadLine();
        }
    }
}
