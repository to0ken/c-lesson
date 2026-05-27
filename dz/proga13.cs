using System;
using System.Collections.Generic;
using System.Linq;

// 1.Validator<T> хранит список правил Predicate<T>, метод Validate(T item) проверяет все правила.
public class Validator<T>
{
    private readonly List<Predicate<T>> _rules = new();


    public Validator<T> AddRule(Predicate<T> rule)
    {
        _rules.Add(rule);
        return this;
    }

    public bool Validate(T item) => _rules.All(rule => rule(item));
}

class Program
{
    static void Main()
    {

        var validator = new Validator<int>()
            .AddRule(x => x > 0)          // 1. Положительное
            .AddRule(x => x % 2 == 0)     // 2. Чётное
            .AddRule(x => x <= 100);      // 3. Не больше 100

        Console.WriteLine($"42  -> {validator.Validate(42)}");   
        Console.WriteLine($"-5  -> {validator.Validate(-5)}");   
        Console.WriteLine($"7   -> {validator.Validate(7)}");    
 
    }
}
