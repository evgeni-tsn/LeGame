namespace LeGame.Classes.Characters
{
    using Interfaces;

    public abstract class Character : IAttacks, IKillable, IMovable
    {
        public abstract int HealthPoints { get; set; }

        public abstract void Attack(IKillable obj);
        public abstract void Move();
    }
}
