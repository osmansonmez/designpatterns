using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection<Item> list = new Collection<Item>();
            list.Add(new Item("item1"));
            list.Add(new Item("item2"));
            list.Add(new Item("item3"));
            list.Add(new Item("item4"));
            list.Add(new Item("item5"));
            list.Add(new Item("item6"));
            list.Add(new Item("item7"));
            list.Add(new Item("item8"));
            list.Add(new Item("item9"));

            Iterator<Item> iterator = list.CreateIterator();
            Console.WriteLine(iterator.Next().ToString());
            Console.WriteLine(iterator.Next().ToString());
            Console.WriteLine(iterator.Next().ToString());
            iterator.Step = 2;
            Console.WriteLine(iterator.Next().ToString());

            List<Item> itemList = new List<Item>();
            itemList.Add(new Item("item1"));
            itemList.Add(new Item("item2"));
            itemList.Add(new Item("item3"));
            itemList.Add(new Item("item4"));
            itemList.Add(new Item("item5"));
            itemList.Add(new Item("item6"));
            itemList.Add(new Item("item7"));
            itemList.Add(new Item("item8"));
            itemList.Add(new Item("item9"));
            IEnumerator<Item> enumList = itemList.GetEnumerator();

            Console.WriteLine(enumList.MoveNext().ToString());
            Console.WriteLine(enumList.MoveNext().ToString());
            Console.WriteLine(enumList.MoveNext().ToString());
            enumList.Reset();
            Console.WriteLine(iterator.Next().ToString());




        }
    }

    /// <summary>
    /// A collection item
    /// </summary>
    class Item
    {
        private string _name;

        // Constructor
        public Item(string name)
        {
            this._name = name;
        }

        // Gets name
        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// The 'Aggregate' interface
    /// </summary>
    interface IAbstractCollection<T> where T : class
    {
        Iterator<T> CreateIterator();
    }

    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    class Collection<T> : IAbstractCollection<T> where T : class
    {
        private ArrayList _items = new ArrayList();

        public Iterator<T> CreateIterator()
        {
            return new Iterator<T>(this);
        }

        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }

        public T Add(T obj)
        {
            _items.Add(obj);
            return obj;
        }

        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }

    /// <summary>
    /// The 'Iterator' interface
    /// </summary>
    interface IAbstractIterator<T>
    {
        T First();
        T Next();
        bool IsDone { get; }
        T CurrentItem { get; }
    }

    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    class Iterator<T> : IAbstractIterator<T> where T : class
    {
        private Collection<T> _collection;
        private int _current = 0;
        private int _step = 1;

        // Constructor
        public Iterator(Collection<T> collection)
        {
            this._collection = collection;
        }

        // Gets first item
        public T First()
        {
            _current = 0;
            return _collection[_current] as T;
        }

        // Gets next item
        public T Next()
        {
            _current += _step;
            if (!IsDone)
                return _collection[_current] as T;
            else
                return null;
        }

        // Gets or sets stepsize
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        // Gets current iterator item
        public T CurrentItem
        {
            get { return _collection[_current] as T; }
        }

        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }
    }
}
