namespace Code.Units
{
    public sealed class EnemyI : Enemy
    {
        protected override void OnDead()
        {
            base.OnDead();
            EnemyController.EnemyPoolI.Despawn(this);
        }
    }
}
