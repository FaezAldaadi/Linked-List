namespace TASK_LINKEDLIST
{
    class Node<T> 
    {
        public T Data;
        public Node<T> Next;
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
    class LinkedList<T>
    {
        Node<T> head;
        public void Addfirst(T data)
        {
            Node<T> newOne = new Node<T>(data);
            newOne.Next = head;
            head = newOne;
        }
        public void Addlast(T data)
        {
            Node<T> newOne = new Node<T>(data);
            if(head == null)
            {
                head = newOne;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newOne;
            }
        }
        public void AddAt(int index, T data)
        {
            if(index < 0)
            {
                Console.WriteLine("The index must be non-negative");
            }
            Node<T> newOne = new Node<T>(data);
            if(index == 0)
            {
                newOne.Next = head;
                head = newOne;
            }
            else
            {
                Node<T> current = head;
                int currentIndex = 0; 
                while (current != null && currentIndex < index - 1)
                {
                    current = current.Next;
                    currentIndex++;
                }
                if(current == null)
                {
                    throw new ArgumentOutOfRangeException("The index outside the list");
                }
                newOne.Next = current.Next;
                current.Next = newOne;
            }
        }
        public void Removefirst()
        {
            if(head == null)
            {
                throw new InvalidOperationException("The list is empty");
            }
            head = head.Next;
        }
        public void Removelast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty");
            }
            if(head.Next == null)
            {
                head = null;
                return;
            }
            Node<T> current = head;
            while (current.Next.Next != null)
            {
                current = current.Next; 
            }
            current.Next = null;
        }
        public void display()
        {
            Node<T> current = head;
            while(current != null)
            {
                Console.Write(current.Data + "\t");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.Addfirst(10);
            list.Addlast(20);
            list.Addlast(8);
            list.AddAt(2,-3);

            Console.WriteLine("The list after added");
            list.display();

            list.Removefirst();
            list.Removelast();

            Console.WriteLine("The list after remove");
            list.display();

        }
    }
}
