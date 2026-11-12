using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Order> orders = new List<Order>
        {
            new Order("Попов", 6000m, new DateTime(2025, 5, 10)),
            new Order("Петров", 3000m, new DateTime(2025, 6, 15)),
            new Order("Сидоров", 4000m, new DateTime(2025, 7, 20)),
            new Order("Иванов", 1500m, new DateTime(2025, 8, 1)),
            new Order("Петров", 2000m, new DateTime(2025, 9, 5)),
            new Order("Смирнов", 1000m, new DateTime(2025, 10, 12)),
            new Order("Смирнов", 500m, new DateTime(2025, 11, 3)),
            new Order("Васильев", 500m, new DateTime(2025, 12, 1)),
            
            new Order("Кузнецов", 10000m, new DateTime(2024, 4, 10)),
            new Order("Иванов", 500m, new DateTime(2024, 5, 20)),
            new Order("Соколов", 700m, new DateTime(2024, 6, 15))
        };

        DateTime startDate = new DateTime(2025, 1, 1);
        DateTime endDate = new DateTime(2025, 12, 31);

        var topCustomers = orders
            .Where(o => o.Date >= startDate && o.Date <= endDate)
            .GroupBy(o => o.CustomerName)
            .Select(g => new
            {
                Customer = g.Key,
                TotalSpent = g.Sum(o => o.Amount)
            })
            .OrderByDescending(x => x.TotalSpent)
            .Take(3);

        Console.WriteLine(" Топ-3 клиента по сумме заказов за 2025 год");
        foreach (var client in topCustomers)
        {
            Console.WriteLine($"{client.Customer}: {client.TotalSpent} руб.");
        }
    }
}