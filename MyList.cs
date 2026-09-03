 // using System;
 //    using System.Collections;
 //    using System.Collections.Generic;
 //    
 //    public class MyList<T> : IEnumerable<T>
 //    {
 //        // Количество РЕАЛЬНО ДОБАВЛЕННЫХ элементов в список
 //        private int _count;
 //        
 //        // Внутренний массив, где физически хранятся данные в памяти
 //        private T[] _items;
 //       // Количество элементов, которые СЕЙЧАС находятся в списке
 //       // То есть количество занятых ячеек
 //        public int Length => _count;
 //        // Общая вместимость внутреннего массива
 //        //То есть ВСЕ ячейки: занятые + свободные
 //        public int Capacity => _items.Length;
 //        
 //        
 //        //парковку на 10 мест (Capacity), на которой сейчас стоит 3 машины (Length / _count):
 //        // Capacity (Вместимость) — это размер парковки целиком (длина массива _items.Length). Это число 10.
 //        // Length (Длина / Размер) — это сколько машин приехало и припарковалось (_count). Это число 3.
 //    
 //        public MyList()
 //        {
 //            _items = new T[0];
 //            
 //        }
 //    
 //    public MyList(int capacity)
 //    {
 //        if (capacity < 0)
 //        {
 //            throw new ArgumentOutOfRangeException(nameof(capacity), "Не может быть МЕНЬШЕ нуля");
 //        }
 //    
 //        _items = new T[capacity];
 //    }
 //    
 //    public MyList(IEnumerable<T> collection)
 //    {
 //        if (collection == null)
 //        {
 //            throw new ArgumentNullException(nameof(collection));
 //        }
 //    
 //        _items = new T[4];
 //    
 //        foreach (T item in collection)
 //        {
 //            Add(item);
 //        }
 //    }
 //    
 //    public void Add(T item)
 //    {
 //        if (_count == _items.Length)
 //        {
 //            int newCapacity;
 //    
 //            if (_items.Length == 0)
 //            {
 //                newCapacity = 4;
 //            }
 //            else
 //            {
 //                newCapacity = _items.Length * 2;
 //            }
 //    
 //            T[] newItems = new T[newCapacity];
 //    
 //            for (int i = 0; i < _count; i++)
 //            {
 //                newItems[i] = _items[i];
 //            }
 //    
 //            _items = newItems;
 //        }
 //    
 //        _items[_count] = item;
 //        _count++;
 //    }
 //    
 //    public void AddRange(IEnumerable<T> collection)
 //    {
 //        if (collection == null)
 //        {
 //            throw new ArgumentNullException(nameof(collection));
 //        }
 //    
 //        foreach (T item in collection)
 //        {
 //            Add(item);
 //        }
 //    }
 //    
 //    public void Clear()
 //    {
 //        for (int i = 0; i < _count; i++)
 //        {
 //            _items[i] = default(T);
 //        }
 //        _count = 0;
 //    }
 //    
 //    public int IndexOf(T item)
 //    {
 //        for (int i = 0; i < _count; i++)
 //        {
 //            if (EqualityComparer<T>.Default.Equals(_items[i], item))
 //            {
 //                return i;
 //            }
 //        }
 //        return -1;
 //    }
 //    
 //    public void Remove(int index)
 //    {
 //        if (index < 0 || index >= _count)
 //        {
 //            throw new ArgumentOutOfRangeException(nameof(index));
 //        }
 //    
 //        for (int i = index; i < _count - 1; i++)
 //        {
 //            _items[i] = _items[i + 1]; 
 //        }
 //    
 //        _items[_count - 1] = default(T);
 //        _count--;
 //    }
 //    
 //    public void RemoveAll(T item)
 //    {
 //        int writeIndex = 0;
 //    
 //        for (int readIndex = 0; readIndex < _count; readIndex++)
 //        {
 //            if (!EqualityComparer<T>.Default.Equals(_items[readIndex], item))
 //            {
 //                _items[writeIndex] = _items[readIndex];
 //                writeIndex++;
 //            }
 //        }
 //    
 //        for (int i = writeIndex; i < _count; i++)
 //        {
 //            _items[i] = default(T);
 //        }
 //    
 //        _count = writeIndex;
 //    }
 //    
 //    public void Reverse()
 //    {
 //        int left = 0;
 //        int right = _count - 1;
 //    
 //        while (left < right)
 //        { 
 //            T temp = _items[left]; 
 //            _items[left] = _items[right];
 //            _items[right] = temp;
 //    
 //            left++;
 //            right--;
 //        }
 //    }
 //    
 //    public IEnumerator<T> GetEnumerator()
 //    {
 //        for (int i = 0; i < _count; i++)
 //        {
 //            yield return _items[i];
 //        }
 //    }
 //    
 //    IEnumerator IEnumerable.GetEnumerator()
 //    {
 //        return GetEnumerator();
 //    }
 //    
 //    }
 //    
 //    
 //    
 //    class Program
 //    {
 //        static void Main()
 //        {
 //            MyList<int> list = new MyList<int>();
 //            list.Add(10);
 //            list.Add(20);
 //            list.Add(30);
 //            list.AddRange(new int[] { 40, 50 });
 //
 //            PrintList("Исходный список:", list);
 //
 //            Console.WriteLine($"Индекс числа 30: {list.IndexOf(30)}");
 //
 //            list.Remove(0);      
 //            list.RemoveAll(40);  
 //            list.Reverse();      
 //
 //            PrintList("Список после изменений:", list);
 //
 //            Console.WriteLine($"Занято/Length: {list.Length}");
 //            Console.WriteLine($"Вместимос/Capacity: {list.Capacity}");
 //        }
 //
 //        
 //        static void PrintList(string message, MyList<int> list)
 //        {
 //            Console.Write($"{message} ");
 //            foreach (int n in list)
 //            {
 //                Console.Write(n + " ");
 //            }
 //            Console.WriteLine();
 //        }
 //    }