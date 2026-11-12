using System;

public class Order
{
    public string CustomerName { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Order(string customerName, decimal amount, DateTime date)
    {
        CustomerName = customerName;
        Amount = amount;
        Date = date;
    }
}