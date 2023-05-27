using Code.Shoot;
using Code.UnitMovement;
using UnityEngine;

namespace Code.Units
{
    public sealed class Player : Unit
    {
        [SerializeField] private Transform _gunPoint;

        protected override void OnUpdate()
        {
            base.OnUpdate();
            GunUser?.Use(_gunPoint);
        }
    }
}
