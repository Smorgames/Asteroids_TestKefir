using DataContainers;
using Infrastructure.GameDirectory;
using Infrastructure.Services.Randomizing;
using Logic.Controllers;
using Logic.Models;
using Logic.Pools.BulletPoolDirectory;
using Logic.Pools.EnemyPoolDirectory;
using Logic.Pools.LaserPoolDirectory;
using Logic.Pools.MeteorPoolDirectory;
using ScriptableObjects;
using UnityEngine;

namespace Infrastructure.Services.GameFactoryDirectory
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