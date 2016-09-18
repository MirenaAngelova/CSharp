using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Generic_List
{
     [Version(2, 11)]
    class GenericList<T> where T : IComparable
    {
        const int DefaultCapacity = 4096;
        private T[] elements;
        private int count = 0;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public void Add(T element)
        {
            if (this.count >= this.elements.Length)
            {
                throw new IndexOutOfRangeException("The list capacity was exceeded");
            }
            this.elements[this.count] = element;
            this.count++;
        }

        public T Access(int inde)
        {
            if (inde < 0 || inde >= this.count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            T result = this.elements[inde];
            this.count--;
            return result;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            for (int i = index; i < this.count; i++)
            {
                elements[i] = elements[i + 1];
            }
        }

        public void Insert(T element, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            int size = this.elements.Length;

            while (index + 1 >= size)
            {
                size *= 2;
            }
            T[] newArray = new T[size];
            Array.Copy(this.elements, 0, newArray, 0, index);
            newArray[index] = element;

            if (index > this.count)
            {
                this.count = index + 1;
            }
            else
            {
                this.count++;
                Array.Copy(this.elements, index, newArray, index + 1, this.count - index - 1);
            }
            this.elements = newArray;
        }

        public void Clear()
        {
            this.elements = new T[this.elements.Length];
        }

        public int FindIndexOf(T element)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (elements[i].Equals(element))
                {
                    return i;
                }

            }
            return -1;
        }

        public bool Contains(T element)
        {
            bool containts = this.FindIndexOf(element) != -1;
            return containts;
        }



        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.count; i++)
            {
                result.Append(this.elements[i]);
                if (i != this.count - 1)
                {
                    result.Append(", ");
                }
            }
            return result.ToString();
        }

        public void ShowVersion()
        {
            Type type = typeof(GenericList<T>);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (var version in allAttributes)
            {
                if (version is VersionAttribute)
                {
                    VersionAttribute temp = version as VersionAttribute;
                    Console.WriteLine("GenericList v.{0}.{1}", temp.Major, temp.Minor);
                }
            }
        }
    }
}
