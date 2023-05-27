using UnityEngine;
using LasyDI;
using LasyDI.Pool;

using Code.Units;
using Code.Shoot;
using Code.GUI;
using Code.Pool;
using Code.UnitMovement;
using Code.UnitHealth;
using Code.Settings;

namespace Code.Installlers
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSetting _gameSetting;
        [SerializeField] private PlayerInfoScreen _playerInfoScreen;

        private void Reset()
        {
            name = nameof(GameInstaller);
        }

        public override void OnInstall()
        {
            //GUI
            LasyContainer
                .Bind<PlayerInfoScreen>()
                .WhereInstance(_playerInfoScreen)
                .AsSingle();

            //POOL
            LasyContainer
                .BindPool<EnemyIPool, EnemyI>()
                .FromPrefab(_gameSetting.EnemyIPrefab)
                .WhereAbstraction<IUnitMovement>()
                .FromContainer<EnemyMovement>()
                .WhereAbstraction<IUnitHealth>()
                .FromContainer<EnemyHealth>();

            LasyContainer
                .BindPool<EnemyIIPool, EnemyII>()
                .FromPrefab(_gameSetting.EnemyIIPrefab)
                .WhereAbstraction<IUnitMovement>()
                .FromContainer<EnemyMovement>()
                .WhereAbstraction<IUnitHealth>()
                .FromContainer<EnemyHealth>();

            LasyContainer
                .BindPool<BulletPool, Bullet>()
                .FromPrefab(_gameSetting.BulletPrefab)
                .WhereAbstraction<IUnitMovement>()
                .FromContainer<BulletMovement>()
                .WhereAbstraction<IUnitHealth>()
                .FromContainer<EnemyHealth>();

            //MOVEMENT
            LasyContainer
                .Bind<IUnitMovement, EnemyMovement>()
                .AsSingle();

            LasyContainer
                .Bind<IUnitMovement, BulletMovement>()
                .AsSingle();

            LasyContainer
                .Bind<IUnitMovement, PlayerMovement>()
                .AsSingle();

            //HEALTH
            LasyContainer
                .Bind<IUnitHealth, PlayerHealth>()
                .AsSingle();

            LasyContainer
                .Bind<IUnitHealth, EnemyHealth>();

            //GUN
            LasyContainer
                .Bind<IShoot, SingleShootGun>()
                .AsSingle();

            LasyContainer
                .Bind<IShoot, ArrayShootGun>()
                .AsSingle();

            LasyContainer
               .Bind<IGunUser, PlayerGunUser>()
               .WhereAbstraction<IShoot>()
               .FromContainer<SingleShootGun, ArrayShootGun>()
               .AsSingle();

            //MAIN
            LasyContainer
                .Bind<Player>()
                .FromGameObjectOnScene()
                .WhereAbstraction<IUnitMovement>()
                .FromContainer<PlayerMovement>()
                .WhereAbstraction<IGunUser>()
                .FromContainer<PlayerGunUser>()
                .WhereAbstraction<IUnitHealth>()
                .FromContainer<PlayerHealth>()
                .IsAutoCreated()
                .AsSingle();

            LasyContainer
                .Bind<EnemyController>()
                .WithParameters(_gameSetting)
                .IsAutoCreated()
                .AsSingle();
        }
    }
}
