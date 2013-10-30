using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Model
{
    public class SingleLinkedList<T>
    {
        private SingleLinkedListNode<T> _head = null;
        private SingleLinkedListNode<T> _tail = null;

        public SingleLinkedList()
        {
        }

        public void Add(T pValue) {
            var node = new SingleLinkedListNode<T>(pValue);

            if (_head == null)
            {
                // initialise list
                _head = node;
                _tail = node;
            }
            else
            {
                // update the end of the list
                _tail.Next = node;
                _tail = node;
            }
        }

        public SingleLinkedListNode<T> First
        {
            get { return _head; } 
        }

        public SingleLinkedListNode<T> Last
        {
            get { return _tail; } 
        }

        public bool Contains(T pValue)
        {
            bool result = false;

            var node = _head;

            while (node != null && !EqualityComparer<T>.Default.Equals(node.Value, pValue))
                node = node.Next;

            if (node != null)
                result = true; 

            return result;
        }

        public bool Remove(T pValue) {
            // returns true if the value was found and removed
            var node = _head;
            
            if (node == null)
                return false; // no nodes in list

            // check _head first
            if (EqualityComparer<T>.Default.Equals(node.Value, pValue))
            {
                // check head and tail
                if (node == _tail)
                {
                    // only one node in list
                    // reset list
                    _head = null;
                    _tail = null;
                }
                else
                {
                    // value is in the first node
                    // get rid of current head
                    // set it to next node in list
                    _head = node.Next;
                }

                // found the value in list
                return true;
            }

            // loop through the next node in the list
            while (node.Next != null && !EqualityComparer<T>.Default.Equals(node.Next.Value, pValue))
                node = node.Next;

            if (node.Next != null)
            {
                // found the value in node.next
                if (node.Next == _tail)
                    _tail = node; // reset tail

                // value found in middle of list
                // reset next reference
                node.Next = node.Next.Next;
                return true;
            }

            return false; // value not found in list
        }

        public IEnumerable<T> Traverse()
        {
            var node = _head;

            // loop through entire list
            while (node != null)
            {
                yield return node.Value; // return value and execution to calling code
                node = node.Next;
            }
        }
    }

    public class SingleLinkedListNode<T>
    {
        private SingleLinkedListNode<T> _nextnode = null;
        private T _value;

        public SingleLinkedListNode(T pValue)
        {
            _value = pValue;
        }


        public SingleLinkedListNode<T> Next { 
            get { return _nextnode; } 
            set { _nextnode = value; } 
        }
        
        public T Value { 
            get { return _value; } 
        }
    }

    
}
