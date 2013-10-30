using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Datos.Model;

namespace Datos.Test
{
    [TestFixture]
    public class SingleLinkedListTests
    {
        [Test]
        public void must_add_node_with_correct_value()
        {
            // assemble
            var list = new SingleLinkedList();

            // act
            list.Add(10);

            // assert
            Assert.AreEqual(10, list.First.Value);
            
        }

        [Test]
        public void head_and_tail_must_have_correct_values()
        {
            // assemble
            var list = new SingleLinkedList();

            // act
            list.Add(5);
            list.Add(15);

            // assert
            Assert.AreEqual(5, list.First.Value);
            Assert.AreEqual(15, list.Last.Value);
        }

        [Test]
        public void add_value_must_be_in_correct_order()
        {
            // assemble
            var list = new SingleLinkedList();

            // act
            list.Add(5);
            list.Add(15);
            list.Add(45);

            var node = list.First;

            // assert
            Assert.AreEqual(5, node.Value);
            Assert.AreEqual(15, node.Next.Value);
            Assert.AreEqual(45, node.Next.Next.Value);
        }


        [Test]
        public void contains_finds_value_in_list()
        {
            // assemble
            var list = new SingleLinkedList();

            // act
            list.Add(5);
            list.Add(15);
            list.Add(45);

            // assert
            Assert.AreEqual(true, list.Contains(5));
            Assert.AreEqual(true, list.Contains(15));
            Assert.AreEqual(true, list.Contains(45));
        }

        [Test]
        public void contains_does_not_find_value_in_list()
        {
            // assemble
            var list = new SingleLinkedList();

            // act
            list.Add(5);
            list.Add(15);
            list.Add(45);

            // assert
            Assert.AreEqual(false, list.Contains(99));
        }

        [Test]
        public void remove_empty_list()
        {
            // assemble
            var list = new SingleLinkedList();

            // act

            // assert
            Assert.AreEqual(false, list.Remove(99));
            Assert.IsNull(list.First);
            Assert.IsNull(list.Last);
        }

        [Test]
        public void remove_one_node_in_list_with_only_one_node()
        {
            // assemble
            var list = new SingleLinkedList();

            // act
            list.Add(5);

            // assert
            Assert.AreEqual(true, list.Remove(5));
            Assert.IsNull(list.First);
            Assert.IsNull(list.Last);
        }

        [Test]
        public void remove_first_node_in_list_with_multiple_nodes()
        {
            // assemble
            var list = new SingleLinkedList();

            // act
            list.Add(5);
            list.Add(10);
            list.Add(15);

            // assert
            Assert.AreEqual(true, list.Remove(5));
            Assert.AreEqual(10, list.First.Value);
            Assert.AreEqual(15, list.Last.Value);
        }

        [Test]
        public void remove_node_in_middle_of_list_with_multiple_nodes()
        {
            // assemble
            var list = new SingleLinkedList();

            // act
            list.Add(5);
            list.Add(10);
            list.Add(15);

            // assert
            Assert.AreEqual(true, list.Remove(10));
            Assert.AreEqual(5, list.First.Value);
            Assert.AreEqual(15, list.Last.Value);
            Assert.AreEqual(15, list.First.Next.Value);
        }

        [Test]
        public void remove_last_node_in_list_with_multiple_nodes()
        {
            // assemble
            var list = new SingleLinkedList();

            // act
            list.Add(5);
            list.Add(10);
            list.Add(15);

            // assert
            Assert.AreEqual(true, list.Remove(15));
            Assert.AreEqual(5, list.First.Value);
            Assert.AreEqual(10, list.Last.Value);
            Assert.AreEqual(10, list.First.Next.Value);
        }

        [Test]
        public void iterate_through_entire_list_and_yield_results()
        {
            // assemble
            var list = new SingleLinkedList();

            // act
            list.Add(5);
            list.Add(10);
            list.Add(15);

            var result = "";

            foreach (var item in list.Traverse())
            {
                result += item.ToString();
            }

            // assert
            Assert.AreEqual("51015", result);
            
        }
    }
}
