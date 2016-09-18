using System;
using Empires6.Constants;

namespace Empires6.Validations
{
    public static class Validator
    {
        public static void ValidateType<T>(T type, string unitType)
        {
            if (type == null)
            {
                throw new ArgumentNullException(string.Format(Constant.ErrorAssemblyMessage, unitType));
            }
        }

        public static void ValidatePropertyHealth(int initialHealth, string limit, string type)
        {
            if (initialHealth <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(Constant.UnitsPropertyLength, limit, type));
            }
        }

        public static void ValidatePropertyDamage(int damage, string limit, string type)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(Constant.UnitsPropertyLength, limit, type));
            }
        }

        public static void ValidatePropertyQuantity(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(Constant.ResourcesPropertyLength);
            }
        }

        public static void ValidateTypes<T>(T type, string name)
        {
            if (type == null)
            {
                throw new ArgumentNullException(string.Format(Constant.NullException, name));
            }
        }

        public static void ValidatePropertyTurns(int value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(string.Format(Constant.PropertyTurns, name));
            }
        }
    }
}