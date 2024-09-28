/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: The user shall specify the maximum size of the Customer Service Queue when it is created.
        // If the size is invalid (less than or equal to 0) then the size shall default to 10. 
        // Expected Result: 
        Console.WriteLine("Test 1");

        var test1_1 = new CustomerService(10);
        Console.WriteLine(test1_1);
        var test1_2 = new CustomerService(0);
        Console.WriteLine(test1_2);
        var test1_3 = new CustomerService(-1);
        Console.WriteLine(test1_3);
        var test1_4 = new CustomerService(5);
        Console.WriteLine(test1_4);

        // Defect(s) Found: Not found.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: The AddNewCustomer method shall enqueue a new customer into the queue.
        // Expected Result: 
        Console.WriteLine("Test 2");

        var test2 = new CustomerService(1);
        test2._queue.Add(new Customer("Mike", "1", "power down"));
        Console.WriteLine(test2);

        // Defect(s) Found: Not Found

        Console.WriteLine("=================");

        // Test 3
        // Scenario: If the queue is full when trying to add a customer, then an error message will be displayed.
        // Expected Result: 
        // Faild to show prompt for the 2nd cutomer's info because it's bigger than 1, the max size.
        // Show a error message.
        Console.WriteLine("Test 3");
        var test3 = new CustomerService(1);
        var test3newC = new Customer("jen", "1", "nothing");
        test3._queue.Add(test3newC);
        test3.AddNewCustomer();

        Console.WriteLine(test3);

        // Defect(s) Found: The operation missed a "=". Where it check if queue count is bigger than max size.

        Console.WriteLine("=================");
        // Test 4
        // Scenario: The ServeCustomer function shall dequeue the next customer from the queue and display the details.
        // Expected Result: Should show Jen's info.
        Console.WriteLine("Test 4");

        var test4 = new CustomerService(2);
        var test4newC = new Customer("Jen", "1", "nothing");
        var test4newC2 = new Customer("Mike", "2", "Too cold");
        test4._queue.Add(test4newC);
        test4._queue.Add(test4newC2);
        test4.ServeCustomer();
        // Defect(s) Found: It Removes the first customer before set it to a var for the dequeue customer.

        Console.WriteLine("=================");
        // Test 5
        // Scenario: If the queue is empty when trying to serve a customer, then an error message will be displayed.
        // Expected Result: Show error message
        Console.WriteLine("Test 5");
        var test5 = new CustomerService(2);
        test5.ServeCustomer();


        // Defect(s) Found: The serveCustomer function didn't have condition to check if there's any customer.

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if(_queue.Count == 0){
            Console.WriteLine("There are no customer yet.");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}