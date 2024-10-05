using System.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Enqueue function shall add an item (which contains both data and priority) to the back of the queue.
        // - Add 2 items in the queue.
    // Expected Result: 2
    // Defect(s) Found: Nothing.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("dog", 1);
        priorityQueue.Enqueue("cat", 2);

        Assert.AreEqual(2, priorityQueue.Length);
    }

    [TestMethod]
    // Scenario: The Dequeue function shall remove the item with the highest priority and return its value.
        // - Add 3 items with different names and values.
    // Expected Result: "cat", "cow", "dog"
    // Defect(s) Found: In the dequeue function, it didn't remove the item after extract its value. Also, the for loop setting is wrong, it will not start to compare if there is only 2 items.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("dog", 1);
        priorityQueue.Enqueue("cat", 20);
        priorityQueue.Enqueue("cow", 2);

        string[] expectedResult = ["cat", "cow", "dog"];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], item);
        }
    }

    [TestMethod]
    // Scenario: If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
        // - create queue with 3 object but two of them have the same value
    // Expected Result: "cat", "cow", "dog"
    // Defect(s) Found: In the dequeue function, in the if statement on line 31 remove the equal sign, so it won't replace the index when the two priority value are equal. 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("dog", 1);
        priorityQueue.Enqueue("cat", 20);
        priorityQueue.Enqueue("cow", 20);

        string[] expectedResult = ["cat", "cow", "dog"];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], item);
        }

    }

    [TestMethod]
    // Scenario: If the queue is empty, then an error exception shall be thrown. 
        // - create an empty queue and run it
    // Expected Result: thrown an error
    // Defect(s) Found: Not found 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
    
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);

    }
}