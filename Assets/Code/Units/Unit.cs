using UnityEngine;
using LasyDI;

using Code.Shoot;
using Code.UnitMovement;
using Code.UnitHealth;
using Code.Settings;

namespace Code.Units
{
    [RequireComponent(typeof(CapsuleCollider), typeof(Rigidbody))]
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private UnitSetting _unitSetting;

        [Inject]
        public virtual void Construct(
            IUnitMovement movement,
            IGunUser gunUser,
            IUnitHealth unitHealth)
        {
            Movement = movement;
            Movement.Speed = _unitSetting.Speed;

            GunUser = gunUser;

            UnitHealth = unitHealth;
            UnitHealth.Health = _unitSetting.Health;

            Rigidbody = GetComponent<Rigidbody>();
        }

        public Rigidbody Rigidbody { get; private set; }

        protected IUnitMovement Movement { get; private set; } 
        protected IGunUser GunUser { get; private set; } 
        protected IUnitHealth UnitHealth { get; private set; }

        private void Update()
        {
            Movement?.Move(this);
            OnUpdate();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<Unit>(out var unit))
            {
                TakeDamage(15);
                unit.TakeDamage(15);
            }
        }

        public void TakeDamage(int damage)
        {
            UnitHealth.TakeDamage(damage);

            if (UnitHealth.IsDead)
            {
                OnDead();
            }
        }

        protected virtual void OnUpdate() { }
        protected virtual void OnDead() { }
    }
}

