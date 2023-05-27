using UnityEngine;

namespace Code.Shoot
{
    public interface IShoot
    {
        string GunName { get; }
        void Shoot(Transform gunPoint);
    }
}
