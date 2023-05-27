using UnityEngine;
using Code.Units;

namespace Code.UnitMovement
{
    public sealed class BulletMovement : IUnitMovement
    {
        public float Speed { get; set; }

        public void Move(Unit owner)
        {
            owner.Rigidbody.velocity = owner.transform.forward * Speed;
        }
    }
}
