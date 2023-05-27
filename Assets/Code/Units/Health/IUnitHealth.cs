namespace Code.UnitHealth
{
    public interface IUnitHealth
    {
        int Health { get; set; }
        bool IsDead { get; }
        void TakeDamage(int damage);
    }
}
