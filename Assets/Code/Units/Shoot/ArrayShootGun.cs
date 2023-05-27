using UnityEngine;

using Code.Pool;

namespace Code.Shoot
{
    public sealed class ArrayShootGun : CommonShootGun
    {
        private const int BulletCount = 5;
        private const float BulletOffset = .75f;

        public ArrayShootGun(BulletPool bulletPool) : base(bulletPool)
        {

        }

        public override string GunName => "ShootGun";

        public override void Shoot(Transform gunPoint)
        {
            for (var i = 0; i <= BulletCount; ++i)
            {
                CreateBullet(GetRandomPoint(gunPoint), gunPoint.forward);
            }
        }

        private Vector3 GetRandomPoint(Transform gunPoint)
        {

            return gunPoint.position + Random.insideUnitSphere * BulletOffset;
        }
    }
}
