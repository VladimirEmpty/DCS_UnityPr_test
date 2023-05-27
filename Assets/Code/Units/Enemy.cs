using LasyDI;
using Code.UnitMovement;
using Code.UnitHealth;

namespace Code.Units
{
    public abstract class Enemy: Unit
    {

        [Inject]
        public void Construct(
            IUnitMovement movement,
            IUnitHealth unitHealth,
            EnemyController enemyController)
        {
            EnemyController = enemyController;
            base.Construct(movement, null, unitHealth);
        }
        protected EnemyController EnemyController { get; private set; }
    }
}
