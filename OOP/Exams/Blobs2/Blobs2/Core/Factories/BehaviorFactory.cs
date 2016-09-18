namespace Blobs2.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Interfaces;

    public class BehaviorFactory : IBehaviorFactory
    {
        private const string ExceptionMessage = "Unknown behavior type.";
        /// <summary>
        /// Using reflection to find behaviorable element
        /// </summary>
        /// <param name="behaviorName"></param>
        /// <returns>returns behavior cast to IBehavior</returns>
        public IBehavior Create(string behaviorName)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == behaviorName);
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type), ExceptionMessage);
            }

            var behavior = Activator.CreateInstance(type);
            return behavior as IBehavior;
        }
    }
}