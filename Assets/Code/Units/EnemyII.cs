
namespace Code.Units
{
    public sealed class EnemyII : Enemy
    {
        protected override void OnDead()
        {
            base.OnDead();
            EnemyController.EnemyPoolII.Despawn(this);
        }
    }
}
