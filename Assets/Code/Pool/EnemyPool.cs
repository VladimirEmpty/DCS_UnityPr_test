using UnityEngine;
using LasyDI.Pool;

using Code.Units;

namespace Code.Pool
{
    public abstract class EnemyPool<T> : BasePoolObjectDI<T>
        where T : Unit
    {
        public T Spawn(Vector3 position)
        {
            var result = base.Spawn();
            result.transform.position = position;

            return result;
        }

        public override void OnDespawn(T currentObject)
        {
            base.OnDespawn(currentObject);
            currentObject.gameObject.SetActive(false);
        }

        public override void OnSpawn(T currentObject)
        {
            base.OnSpawn(currentObject);
            currentObject.gameObject.SetActive(true);
        }
    }
}
