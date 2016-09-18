using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _06.BitArray
{
    class BitArrayBigInteger
    {
        private int bits;
        private BigInteger number;

        public BitArrayBigInteger(int bits)
        {
            this.Bits = bits;
        }

        public int Bits
        {
            get { return this.bits; }
            private set
            {
                if (value < 0 || value > 100000)
                {
                    throw new ArgumentOutOfRangeException("value", "Bits should be between [1...100000].");
                }
                this.bits = value;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > this.Bits - 1)
                {
                    throw new IndexOutOfRangeException(String.Format("Index should be between [1...{0}]", this.bits - 1));
                }
                if ((number & ((BigInteger)1 << index)) == 0)
                {
                    return 0;
                }
                return 1;
            }
            set
            {
                if (index < 0 || index > this.Bits - 1)
                {
                    throw new IndexOutOfRangeException(String.Format("Index should be between [1...{0}]", this.bits - 1));
                }
                if (value != 0 && value != 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Bits should be only 0 or 1.");
                }
                this.number &= ~((BigInteger)1 << index);
                this.number |= ((BigInteger) value << index);
            }
        }

        public override string ToString()
        {
            return number.ToString();
        }
    }
}
