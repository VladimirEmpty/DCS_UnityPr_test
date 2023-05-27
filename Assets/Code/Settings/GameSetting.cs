using UnityEngine;

using Code.Units;

namespace Code.Settings
{
    [CreateAssetMenu(fileName = nameof(GameSetting), menuName = "Setting/GameSetting")]
    public sealed class GameSetting : ScriptableObject
    {
        [SerializeField] private EnemyI _enemyIPrefab;
        [SerializeField] private EnemyII _enemyIIPrefab;
        [SerializeField] private Bullet _bulletPrefab;

        [SerializeField] private float _createRadius;
        [SerializeField] private float _createTimer;
        [SerializeField] private int _enemyInWaveCount;

        public EnemyI EnemyIPrefab => _enemyIPrefab;
        public EnemyII EnemyIIPrefab => _enemyIIPrefab;
        public Bullet BulletPrefab => _bulletPrefab;

        public float CreateRadius => _createRadius;
        public float CreateTimer => _createTimer;
        public int EnemyInWaveCount => _enemyInWaveCount;
    }
}
