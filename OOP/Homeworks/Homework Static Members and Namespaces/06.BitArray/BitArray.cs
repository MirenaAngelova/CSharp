using System;
using System.Numerics;

namespace _06.BitArray
{
    class BitArray
    {
        private bool[] number;
        private int size;

        public BitArray(int size)
        {
            this.Size = size;
            this.Number = new bool[size];
        }

        public bool[] Number
        {
            get { return this.number; }
             private set { this.number = value; }
        }

        public int Size
        {
            get { return this.size; }
            private set
            {
                if (value < 1 || value > 100000)
                {
                   throw new ArgumentOutOfRangeException("value", "Bits should be between [1...100 000]");
                }
                this.size = value;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > this.Size - 1)
                {
                    throw new IndexOutOfRangeException(String.Format("Index should be between [0...{0}]", this.Size - 1));
                }
                return this.GetBit(index);
            }
            set
            {
                if (index < 0 || index > this.Size - 1)
                {
                    throw new IndexOutOfRangeException(String.Format("Index should be between [0...{0}]", this.Size - 1));
                }
                if (value != 0 && value != 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Bits should be only 0 or 1."); 
                }
                SetBit(index, value);
            }
        }

        private int GetBit(int index)
        {
            if (Number[index] == false)
            {
                return 0;
            }
            return 1;
        }

        private void SetBit(int index, int value)
        {
            if (value == 1)
            {
                Number[index] = true;
            }
            else if (value == 0)
            {
                Number[index] = false;
            }
        }

        public override string ToString()
        {
            BigInteger sum = 0;
            for (int i = 0; i < Size; i++)
            {
                if (number[i])
                {
                    sum += ((BigInteger) 1 << i);
                }
            }
            return sum.ToString();
        }
    }
}
