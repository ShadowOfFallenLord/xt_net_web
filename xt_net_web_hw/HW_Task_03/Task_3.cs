using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_03
{
    class DynamicArray<T> : IEnumerable<T>
    {
        protected const int default_capacity = 8;
        protected T[] content;
        protected int size;

        public DynamicArray()
        {
            content = new T[default_capacity];
            size = 0;
        }

        public DynamicArray(int capacity)
        {
            content = new T[capacity];
            size = 0;
        }

        public DynamicArray(IEnumerable<T> list)
        {
            int count = 0;
            foreach (T i in list)
            {
                count++;
            }
            size = count;

            content = new T[size];
            count = 0;
            foreach (T i in list)
            {
                content[count] = i;
                count++;
            }
        }

        protected void UpdateCapacity(int capacity)
        {
            if(capacity < 0)
            {
                capacity = 0;
            }

            T[] new_content = new T[capacity];
            for (int i = 0; i < size; i++)
            {
                new_content[i] = content[i];
            }
            content = new_content;
        }

        public void Add(T obj)
        {
            if(size == content.Length)
            {
                UpdateCapacity(size * 2);
            }

            content[size] = obj;
            size++;
        }

        public void AddRange(IEnumerable<T> list)
        {
            int count = 0;
            foreach (T i in list)
            {
                count++;
            }

            int capacity = content.Length;
            int new_length = size + count;

            while(new_length > capacity)
            {
                capacity += capacity;
            }

            if(capacity != content.Length)
            {
                UpdateCapacity(capacity);
            }

            foreach(T i in list)
            {
                content[size] = i;
                size++;
            }
        }

        public bool Remove(T obj)
        {
            for(int i = 0; i < size; i++)
            {
                if(content[i].Equals(obj))
                {
                    for(int j = i + 1; j < size; j++)
                    {
                        content[j - 1] = content[j];
                    }
                    size--;

                    return true;
                }
            }

            return false;
        }

        public bool Insert(T obj, int index)
        {
            if(index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("index");
            }

            if (size == content.Length)
            {
                UpdateCapacity(size * 2);
            }

            for(int i = size; i > index; i--)
            {
                content[i] = content[i - 1];
            }

            content[index] = obj;

            return true;
        }

        public int Length { get => size; }
        public int Capacity { get => content.Length; }

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private DynamicArray<T> list;
            private int index; 
            public T Current { get; private set; }
 
            internal Enumerator(DynamicArray<T> list) {
                this.list = list;
                index = 0;
                Current = default(T);
            }
 
            public void Dispose()
            {
            }
 
            public bool MoveNext()
            { 
                if (index < list.size) 
                {                                                     
                    Current = list.content[index];                    
                    index++;
                    return true;
                }
                return false;
            }
 
            object IEnumerator.Current { get => Current; }
    
            void IEnumerator.Reset()
            {                
                index = 0;
                Current = default(T);
            } 
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public T this[int index]
        {
            get
            {
                if(index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException("index");
                }

                return content[index];
            }

            set
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException("index");
                }

                content[index] = value;
            }
        }
    }
}
