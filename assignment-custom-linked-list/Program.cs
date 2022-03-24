using System.Collections;
using System.Collections.Generic;

CustomLinkedList<string> cll = new CustomLinkedList<string>();
cll.Add("a");
cll.Add("b");
cll.Add("c");
cll.Add("d");
cll.Add("e");
cll.Add("f");
cll.Add("g");
System.Console.WriteLine("Enumarating CustomLinkedList items with");
System.Console.WriteLine("GetEnumerator:");
foreach (var item in cll)
    System.Console.WriteLine(item);

System.Console.WriteLine("GetEnumerableDESC:");
foreach (var item in cll.GetEnumeratorDESC())
    System.Console.WriteLine(item);

public class CustomLinkedList<T> : IEnumerable
{
    private Node _head;
    private Node _tail;
    public void Add(T input)
    {
        Node node = new Node(input);
        if (_tail == null)
            _head = node;
        else
        {
            node.Previous = _tail;
            _tail.Next = node;
        }
        _tail = node;
    }

    public IEnumerator GetEnumerator()
    {
        Node current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    public IEnumerable GetEnumeratorDESC()
    {
        Node current = _tail;
        while (current != null)
        {
            yield return current.Value;
            current = current.Previous;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public class Node
    {
        public T Value;
        public Node Previous;
        public Node Next;
        public Node(T input)
        {
            Value = input;
            Previous = null;
            Next = null;
        }
    }
}