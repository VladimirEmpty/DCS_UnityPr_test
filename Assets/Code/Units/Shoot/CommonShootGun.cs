using UnityEngine;

using Code.Pool;

namespace Code.Shoot
{
    public abstract class CommonShootGun : IShoot
    {
        protected const float BulletLifeTime = 2.5f;
        protected BulletPool bulletPool;

        public CommonShootGun(BulletPool bulletPool)
        {
            this.bulletPool = bulletPool;
        }

        public abstract string GunName { get; }

        public abstract void Shoot(Transform gunPoint);

        protected virtual void CreateBullet(Vector3 point, Vector3 direction)
        {
            var bullet = bulletPool.Spawn();
            bullet.transform.position = point;
            bullet.transform.forward = direction;

            bullet.Inititialize(BulletLifeTime);
        }
    }
}
