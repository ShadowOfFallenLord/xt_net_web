using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_03
{
    class HardDynamicArray<T> : DynamicArray<T>, ICloneable
    {
        public HardDynamicArray() : base()
        {
            //
        }

        public HardDynamicArray(int capacity) : base(capacity)
        {
            //
        }

        public HardDynamicArray(IEnumerable<T> list) : base(list)
        {
            //
        }

        protected override void UpdateCapacity(int capacity)
        {
            if(capacity < size)
            {
                size = capacity;
            }
            base.UpdateCapacity(capacity);
        }

        public override T this[int index]
        {
            get
            {
                if (index >= 0)
                {
                    return base[index];
                }
                
                if(-index > Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                return content[content.Length + index];
            }
            set
            {
                if (index >= 0)
                {
                    base[index] = value;
                }

                if (-index > Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                content[content.Length + index] = value;
            }
        }

        public new int Capacity
        {
            get => base.Capacity;
            set
            {
                UpdateCapacity(value);
            }
        }

        public object Clone()
        {
            return new HardDynamicArray<T>(content.Take(size));
        }

        public T[] ToArray()
        {
            T[] res = new T[size];

            for(int i = 0; i < size; i++)
            {
                res[i] = content[i];
            }

            return res;
        }
    }
}
