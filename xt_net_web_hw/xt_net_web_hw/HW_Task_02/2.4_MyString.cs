using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02
{
    class MyString : IComparable<MyString>
    {
        private char[] content;
		public char this[int index] => content[index];
        public int Length => content.Length;

        public MyString(string init)
        {
            content = init.ToCharArray();
        }

        public MyString(char[] init)
        {
            content = init.ToArray();
        }

        public int CompareTo(MyString t)
        {
            if (content.Length > t.content.Length) return -1;
            if (content.Length < t.content.Length) return 1;

			for(int i = 0; i < content.Length; i++)
            {
                if (content[i] > t.content[i]) return -1;
                if (content[i] < t.content[i]) return 1;
            }

            return 0;
        }

        public void Concat(MyString s)
        {
            char[] new_content = new char[content.Length + s.Length];

            for (int i = 0; i < content.Length; i++)
            {
                new_content[i] = content[i];
            }

            for (int i = 0; i < s.Length; i++)
            {
                new_content[i + content.Length] = s[i];
            }

            content = new_content;
        }

        public void Concat(string s)
        {
            Concat(new MyString(s));
        }

        public int Find(char c)
        {
            for(int i = 0; i < content.Length; i++)
            {
				if(content[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(Length);
            builder.Append(content);
            return builder.ToString();
        }

        public static explicit operator char[](MyString myString)
        {
            return myString.content.ToArray();
        }

        public static explicit operator MyString(char[] chars)
        {
            return new MyString(chars);
        }
    }
}
