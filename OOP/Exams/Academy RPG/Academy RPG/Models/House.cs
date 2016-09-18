namespace Academy_RPG.Models
{
    using AcademyRPG;
    public class House : StaticObject, IWorldObject
    {
        public House(Point position, int owner) : base(position, owner)
        {
            base.HitPoints = 500;
        }
    }
}
