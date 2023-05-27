using UnityEngine;

using Code.Pool;

namespace Code.Shoot
{
    public sealed class SingleShootGun : CommonShootGun
    {
        public SingleShootGun(BulletPool bulletPool) : base(bulletPool)
        {

        }
        public override string GunName => "Pistol";
        public override void Shoot(Transform gunPoint)
        {
            CreateBullet(gunPoint.position, gunPoint.forward);
        }
    }
}
