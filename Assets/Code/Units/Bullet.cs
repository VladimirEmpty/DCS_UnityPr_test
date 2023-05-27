using UnityEngine;
using LasyDI;

using Code.UnitMovement;
using Code.UnitHealth;
using Code.Pool;

namespace Code.Units
{
    public sealed class Bullet : Unit
    {
        private BulletPool _bulletPool;
        private float _timer;

        [Inject]
        public void Construct(
            IUnitMovement movement,
            IUnitHealth unitHealth,
            BulletPool bulletPool)
        {
            base.Construct(movement, null, unitHealth);
            _bulletPool = bulletPool;
        }

        public void Inititialize(float lifeTimer)
        {
            _timer = Time.time + lifeTimer;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if(_timer <= Time.time)
            {
                OnDead();
            }
        }

        protected override void OnDead()
        {
            base.OnDead();
            _bulletPool.Despawn(this);
        }
    }
}
