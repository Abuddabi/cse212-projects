using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with two different priorities and dequeue twice.
    // Expected Result: The item with the highest priority is dequeued first, followed by the item that was enqueued first among those with the same priority.
    // Defect(s) Found: 
    // 1. In PriorityQueue.Dequeue, the for loop's condition was incorrect, causing it to skip the last item in the queue. Changed 'index < _queue.Count - 1' to 'index < _queue.Count' to ensure all items are considered when determining the highest priority.
    // 2. In PriorityQueue.Dequeue, the method did not remove the item from the queue after identifying it. Added '_queue.RemoveAt(highPriorityIndex);' to ensure the dequeued item is removed from the queue.
    // 3. In PriorityQueue.Dequeue, the comparison for determining the highest priority was incorrect. Changed 'if (Priority >= Priority)' to 'if (Priority > Priority)' to ensure the FIFO order is maintained.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 2);
        Assert.AreEqual("[Bob (Pri:2)]", priorityQueue.ToString());

        priorityQueue.Enqueue("Tim", 2);
        priorityQueue.Enqueue("Sue", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Sue", result);

        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("Bob", result2);
    }

    [TestMethod]
    // Scenario: Enqueue one item and dequeue twice.
    // Expected Result: Exception is thrown when trying to dequeue from an empty queue. 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 10);
        priorityQueue.Dequeue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    // Add more test cases as needed below.
}