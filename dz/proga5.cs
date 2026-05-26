
using System.Diagnostics;
using System.Linq.Expressions;

// 1.Создать метод банковского перевода пользователя между счетами с помощью дочерних и родительских классов.

class BankCard
{
    public string Name { get; set; }
    public decimal Balance { get; set; }

    public BankCard(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
    }

    public void Transfer(BankCard target, decimal amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            target.Balance += amount;
            Console.WriteLine($" {amount} переведенона {target.Name}");
        }
        else
        {
            Console.WriteLine("Перевод невозможен");
        }
    }
}

class secondCard : BankCard
{
    public secondCard(string name, decimal balance) : base(name, balance) { }
}

class Program
{
    static void Main()
    {
        var card1 = new BankCard("Иван", 1000m);  
        var card2 = new secondCard("Ольга", 200m);  


        Console.WriteLine($"{card1.Name}: {card1.Balance}₽ | {card2.Name}: {card2.Balance}₽\n");

        card1.Transfer(card2, 300m);

        Console.WriteLine($"{card1.Name}: {card1.Balance}₽ | {card2.Name}: {card2.Balance}₽");
    }
}
