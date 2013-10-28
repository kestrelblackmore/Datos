using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Model
{
    public class SingleLinkedList
    {
        private SingleLinkedListNode _head = null;
        private SingleLinkedListNode _tail = null;

        public SingleLinkedList()
        {
        }

        public void Add(int value) {
            var node = new SingleLinkedListNode(value);

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

        public SingleLinkedListNode First()
        {
            return _head;
        }

        public SingleLinkedListNode Last()
        {
            return _tail;
        }

        public bool Contains(int value)
        {
            bool result = false;

            var node = _head;

            while (node != null && node.Value != value)
            {
                node = node.Next;
            }

            if (node != null)
            {
                result = true; 
            }

            return result;
        }

        public bool Remove(int value) {
            // returns true if the value was found and removed
            var node = _head;
            
            if (node == null)
                return false; // no nodes in list

            // check _head first
            if (node.Value == value)
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
            while (node.Next != null && node.Next.Value != value)
            {
                node = node.Next;
            }

            if (node.Next != null)
            {
                // found the value 
                if (node.Next == _tail)
                {
                    // reset tail
                    _tail = node;
                }

                // value found in middle of list
                // reset next reference
                node.Next = node.Next.Next;
                return true;
            }

            return false; // value not found in list
        }
    }

    public class SingleLinkedListNode
    {
        private SingleLinkedListNode _nextnode = null;
        private int? _value = null;

        public SingleLinkedListNode(int value)
        {
            _value = value;
        }


        public SingleLinkedListNode Next { 
            get { return _nextnode; } 
            set { _nextnode = value; } 
        }
        
        public int? Value { get { return _value; } }
    }

    
}
