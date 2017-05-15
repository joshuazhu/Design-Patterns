using System;
using System.Collections.Generic;
using TemplateMethodPattern;

namespace BuilderPattern
{
public class DirectorCashier
{
    public void BuildFood(Builder builder)
    {
        builder.BuildPart1();
        builder.BuildPart2();
    }
}

public abstract class Builder
{
    public abstract void BuildPart1();

    public abstract void BuildPart2();

    public abstract Product GetProduct();
}

public class ConcreteBuilder1 : Builder
{
    protected Product _product;
    public ConcreteBuilder1()
    {
        _product = new Product();
    }
        
    public override void BuildPart1()
    {
        this._product.Add("Hamburger", "2");
    }
        
    public override void BuildPart2()
    {
        this._product.Add("Drink", "1");
    }

    public override Product GetProduct()
    {
        return this._product;
    }
}

public class Product
{
    public Dictionary<string, string> products = new Dictionary<string, string>();
        
    public void Add(string name, string value)
    {
        products.Add(name, value);
    }
        
    public void ShowToClient()
    {
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Key} {p.Value}");
        }
    }
}

public class BuilderPatternRunner : IPatterRunner
{
    public void RunPattern()
    {
        var Builder1 = new ConcreteBuilder1();
        var Director = new DirectorCashier();

        Director.BuildFood(Builder1);
        Builder1.GetProduct().ShowToClient();
    }
}
}
