using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MyList<T> 
    {
        private Node head;
        private int count;

        private class Node
        {
            private Node next;
            private T data;
            
            public Node (T inData)
            {
                next = null;
                data = inData;
            }

            public Node Next
            {
                get { return next; }
                set { next = value; } 
            }

            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        public MyList()
        {
            count = 0;
            head = null;
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(T inData)
        {
            Node n = new Node(inData);
            n.Next = head;
            head = n;
            count++;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }         

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T this[int index]
        {
            get
            {
                int ctr = 0;
                Node current = head;
                while (current != null && ctr <= index)
                {
                    if (ctr == index)
                    {
                        return current.Data;
                    }
                    else
                    {
                        current = current.Next;
                    }
                    ++ctr;
                }
                return default(T);
            }
        }
        
        public override string ToString()
        {
            if (this.head != null)
            {
                return this.head.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
