using UnityEngine;
using LasyDI;

using Code.Settings;
using Code.Pool;
using Code.Units;

namespace Code
{
    //Да я знаю, что это тупо выглядит и прошу прощения!!! Я обнаружил ошибку в моей DLL - LasyDI, которая не поддерживает мульти связку по одному типу, на исправление уйдет много времени.
    //
    public sealed class EnemyController : MonoBehaviour
    {
        private GameSetting _gameSetting;
        private Player _player;

        [Inject]
        public void Construct(
            EnemyIPool poolEnemyI, 
            EnemyIIPool poolEnemyII,
            GameSetting gameSetting,
            Player player)
        {
            _gameSetting = gameSetting;
            _player = player;

            EnemyPoolI = poolEnemyI;
            EnemyPoolII = poolEnemyII;

            InvokeRepeating(nameof(CreateWave), 0f, gameSetting.CreateTimer);
        }

        public EnemyIPool EnemyPoolI { get; private set; }
        public EnemyIIPool EnemyPoolII { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EnemyPoolII.Spawn();
            }
        }

        private void CreateWave()
        {
            for(var i = 0; i < _gameSetting.EnemyInWaveCount; ++i)
            {
                CreateEnemy();
            }
        }

        private void CreateEnemy()
        {
            if(Random.value <= 0.5f)
            {
                EnemyPoolI.Spawn(GetRandomPosition());
            }
            else
            {
                EnemyPoolII.Spawn(GetRandomPosition());
            }
        }

        private Vector3 GetRandomPosition()
        {
            var angle = Random.Range(0, 360f);
            var posX = _player.transform.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * _gameSetting.CreateRadius;
            var posZ = _player.transform.position.z + Mathf.Sin(angle * Mathf.Deg2Rad) * _gameSetting.CreateRadius;

            return new Vector3(posX, _player.transform.position.y, posZ);
        }
    }
}
