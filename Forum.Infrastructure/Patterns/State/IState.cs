public class Order
{
    private IOrderState _state;

    public Order(IOrderState state)
    {
        _state = state;
    }

    public void SetState(IOrderState state)
    {
        _state = state;
    }

    public void NextState() => _state.Next(this);
    public void PrevState() => _state.Prev(this);
    public void PrintStatus() => _state.PrintStatus();
}

public interface IOrderState
{
    void Next(Order order);
    void Prev(Order order);
    void PrintStatus();
}
public class NewOrderState : IOrderState
{
    public void Next(Order order)
    {
        order.SetState(new PaidOrderState());
    }

    public void Prev(Order order)
    {
        Console.WriteLine("The order is in its initial state.");
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order created but not paid yet.");
    }
}

public class PaidOrderState : IOrderState
{
    public void Next(Order order)
    {
        order.SetState(new ShippedOrderState());
    }

    public void Prev(Order order)
    {
        order.SetState(new NewOrderState());
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order has been paid.");
    }
}

public class ShippedOrderState : IOrderState
{
    public void Next(Order order)
    {
        Console.WriteLine("Order already shipped — no next state.");
    }

    public void Prev(Order order)
    {
        order.SetState(new PaidOrderState());
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order has been shipped.");
    }

    class Program
    {
        static void Main()
        {
            var order = new Order(new NewOrderState());

            order.PrintStatus();   
            order.NextState();     
            order.PrintStatus();   
            order.NextState();     
            order.PrintStatus();   
            order.NextState();     
        }
    }

}
