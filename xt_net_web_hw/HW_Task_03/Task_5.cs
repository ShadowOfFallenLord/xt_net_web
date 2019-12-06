using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_03
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base()
        {
            //
        }

        public CycledDynamicArray(int capacity) : base(capacity)
        {
            //
        }

        public CycledDynamicArray(IEnumerable<T> list) : base(list)
        {
            //
        }

        public struct CycledEnumerator : IEnumerator<T>, IEnumerator
        {
            private CycledDynamicArray<T> list;
            private int index;
            public T Current { get; private set; }

            internal CycledEnumerator(CycledDynamicArray<T> list)
            {
                this.list = list;
                index = 0;
                Current = default(T);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (index >= list.size)
                {
                    index = 0;
                }
                Current = list.content[index];
                index++;
                return true;
            }

            object IEnumerator.Current { get => Current; }

            void IEnumerator.Reset()
            {
                index = 0;
                Current = default(T);
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new CycledEnumerator(this);
        }
    }
}
