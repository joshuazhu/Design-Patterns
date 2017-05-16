using System;
using System.Collections.Generic;
using System.Text;
using TemplateMethodPattern;

namespace SingletonPattern
{
    public sealed class Singleton
    {
        private static volatile Singleton _instance;
        private static readonly object _lockThis = new object();

        private Singleton() {}

        public static Singleton GetSingleton()
        {
            if (_instance == null)
            {
                lock (_lockThis)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }

    public class SingletonPatternRunner : IPatterRunner
    {
        public void RunPattern()
        {
            var singleton1 = Singleton.GetSingleton();
            var singleton2 = Singleton.GetSingleton();
        }
    }
}
