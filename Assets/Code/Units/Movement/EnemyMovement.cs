using Code.Units;

namespace Code.UnitMovement
{
    public sealed class EnemyMovement : IUnitMovement
    {
        private readonly Player Target;

        public float Speed { get; set; }

        public EnemyMovement(Player target)
        {
            Target = target;
        }

        public void Move(Unit owner)
        {
            var direction = Target.transform.position - owner.transform.position;
            owner.transform.forward = direction;
            owner.Rigidbody.velocity = owner.transform.forward * Speed;
        }
    }
}
