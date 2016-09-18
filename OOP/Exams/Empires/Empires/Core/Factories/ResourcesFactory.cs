namespace Empires.Core.Factories
{
    using Interfaces;
    using Models.Enum;
    using Models.Resources;

    public class ResourcesFactory : IResourceFactory
    {
        public IResource CreateResource(TypeResource typeResource, int quantity)
        {
            //var type = Assembly.GetExecutingAssembly().GetTypes()
            //    .FirstOrDefault(t => t.Name.Equals(typeResource));
            //if (type == null)
            //{
            //    throw new ArgumentException("Cannot found this type of resource in Assembly.");
            //}

            //var resource = (IResource)Activator.CreateInstance(type, quantity);
            var resource = new Resource(typeResource, quantity);
            return resource;
        }
    }
}
