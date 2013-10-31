using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Model
{
    public class DoubleLinkedList<T>
    {
        private DoubleLinkedListNode<T> _head = null;
        private DoubleLinkedListNode<T> _tail = null;

        public DoubleLinkedList()
        {
        }

        public void Add(T pValue) {
            var node = new DoubleLinkedListNode<T>(pValue);

            if (_head == null)
            {
                // initialise list
                _head = node;
                _tail = node;
            }
            else
            {
                // update the end of the list
                _tail.Next = node; // point current tail next to new added node
                node.Previous = _tail; // point new added nodes previous to current tail
                _tail = node; // reset tail to new node
            }
        }

        public DoubleLinkedListNode<T> First
        {
            get { return _head; } 
        }

        public DoubleLinkedListNode<T> Last
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

            if (_head == null)
                return false; // no nodes in list

            // check _head first
            if (EqualityComparer<T>.Default.Equals(_head.Value, pValue))
            {
                // check head and tail
                if (_head == _tail)
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
                    _head = _head.Next;
                    _head.Previous = null;
                }

                // found the value in list
                return true;
            }

            var node = _head;

            // loop through the next node in the list
            while (node != null && !EqualityComparer<T>.Default.Equals(node.Value, pValue))
                node = node.Next;

            if (node == _tail)
            {
                _tail = _tail.Previous;
                _tail.Next = null;
                
                return true;
            }
            else if (node != null) {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                
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

    public class DoubleLinkedListNode<T>
    {
        private DoubleLinkedListNode<T> _nextnode = null;
        private DoubleLinkedListNode<T> _previousnode = null;
        private T _value;

        public DoubleLinkedListNode(T pValue)
        {
            _value = pValue;
        }


        public DoubleLinkedListNode<T> Next { 
            get { return _nextnode; } 
            set { _nextnode = value; } 
        }

        public DoubleLinkedListNode<T> Previous
        {
            get { return _previousnode; }
            set { _previousnode = value; }
        }

        public T Value { 
            get { return _value; } 
        }
    }

    
}
