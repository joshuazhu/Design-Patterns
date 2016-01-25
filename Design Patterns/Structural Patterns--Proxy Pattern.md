#Proxy Pattern

##Definition
> * Provide a surrogate or placeholder for another object to control access to it.
> * Use an extra level of indirection to support distributed, controlled, or intelligent access.
> * Add a wrapper and delegation to protect the real component from undue complexity.


![uml](http://www.dofactory.com/images/diagrams/net/proxy.gif)

##Applicable situations

There are four common situations in which the Proxy pattern is applicable.

* A **virtual proxy is a placeholder for "expensive to create"** objects. The real object is only created when a client first requests/accesses the object.

* A **remote proxy provides a local representative** for an object that resides in a different address space. This is what the "stub" code in RPC and CORBA provides.

* A **protective proxy controls access to a sensitive master object**. The "surrogate" object checks that the caller has the access permissions required prior to forwarding the request.

* A **smart proxy interposes additional actions when an object is accessed**. Typical uses include: 
Counting the number of references to the real object so that it can be freed automatically when there are no more references (aka smart pointer),
Loading a persistent object into memory when it's first referenced,
Checking that the real object is locked before it is accessed to ensure that no other object can change it.

##Check list
* Identify the leverage or "aspect" that is best implemented as a wrapper or surrogate.

* Define an interface that will make the proxy and the original component **interchangeable**.

* Consider defining a Factory that can encapsulate the decision of whether a proxy or original object is desirable.

* The wrapper class holds **a pointer to the real class** and implements the interface.

* The pointer may be initialized at construction, or on first use.

* Each wrapper method contributes its leverage, and delegates to the wrapper object.

##Sample Codes

>Proxy pattern for a Math object represented by a MathProxy object.

~~~cs
using System;
 
namespace DoFactory.GangOfFour.Proxy.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Proxy Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Create math proxy
      MathProxy proxy = new MathProxy();
 
      // Do the math
      Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
      Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
      Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
      Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Subject interface
  /// </summary>
  public interface IMath
  {
    double Add(double x, double y);
    double Sub(double x, double y);
    double Mul(double x, double y);
    double Div(double x, double y);
  }
 
  /// <summary>
  /// The 'RealSubject' class
  /// </summary>
  class Math : IMath
  {
    public double Add(double x, double y) { return x + y; }
    public double Sub(double x, double y) { return x - y; }
    public double Mul(double x, double y) { return x * y; }
    public double Div(double x, double y) { return x / y; }
  }
 
  /// <summary>
  /// The 'Proxy Object' class
  /// </summary>
  class MathProxy : IMath
  {
    private Math _math = new Math();
 
    public double Add(double x, double y)
    {
      return _math.Add(x, y);
    }
    public double Sub(double x, double y)
    {
      return _math.Sub(x, y);
    }
    public double Mul(double x, double y)
    {
      return _math.Mul(x, y);
    }
    public double Div(double x, double y)
    {
      return _math.Div(x, y);
    }
  }
}
~~~