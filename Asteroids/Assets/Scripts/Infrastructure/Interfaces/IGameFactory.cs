using Gameplay.Controllers;
using Gameplay.Pools.BulletPoolDirectory;
using Gameplay.Pools.EnemyPoolDirectory;
using Gameplay.Pools.LaserPoolDirectory;
using Gameplay.Pools.MeteorPoolDirectory;
using ModelLogic.Data;
using ModelLogic.Data.Configs;
using ModelLogic.Models;
using UnityEngine;

namespace Infrastructure.Interfaces
{
    public interface IGameFactory
    {
        PlayerController CreatePlayer(PlayerData data, IGame game, IBulletPool bulletPool, ILaserPool laserPool);
        BulletController CreateBullet(BulletData data, IBulletPool bulletPool);
        LaserController CreateLaser(UniVector2 startPosition, float rotation, ILaserPool laserPool);
        MeteorController CreateMeteor(MeteorData data, IMeteorPool meteorPool, IGame game, IRandomizer randomizer);
        EnemyController CreateEnemy(EnemyData data, PlayerModel playerModel, IEnemyPool enemyPool, IGame game);
        MeteorController CreateSmallMeteor(MeteorData data, IMeteorPool meteorPool, IGame game, IRandomizer randomizer);
        GameObject CreateEmpty(string name);
    }
}