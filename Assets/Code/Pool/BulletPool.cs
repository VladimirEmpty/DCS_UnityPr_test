using UnityEngine;
using LasyDI.Pool;

using Code.Units;

namespace Code.Pool
{
    public sealed class BulletPool : BasePoolObjectDI<Bullet>
    {
        public override void OnSpawn(Bullet currentObject)
        {
            base.OnSpawn(currentObject);
            currentObject.gameObject.SetActive(true);
        }

        public override void OnDespawn(Bullet currentObject)
        {
            base.OnDespawn(currentObject);
            currentObject.Rigidbody.velocity = Vector3.zero;
            currentObject.Rigidbody.angularVelocity = Vector3.zero;
            currentObject.gameObject.SetActive(false);
        }
    }
}
