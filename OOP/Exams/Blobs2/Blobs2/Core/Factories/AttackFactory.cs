namespace Blobs2.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Interfaces;
    /// <summary>
    /// Using reflection to find attackable element.
    /// </summary>
    public class AttackFactory : IAttackFactory
    {
        private const string ExceptionMessage = "Unknown attack type.";

        public IAttack Create(string attackName)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == attackName);
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type), ExceptionMessage);
            }

            var attack = (IAttack) Activator.CreateInstance(type);
            return attack;//return attack as IAttack;
        }
    }
}
