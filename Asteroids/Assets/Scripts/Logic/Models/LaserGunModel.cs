using System;
using DataContainers;
using Logic.Pools.LaserPoolDirectory;

namespace Logic.Models
{
    public class LaserGunModel
    {
        public Action OnFired;
        public Action OnReloaded;
        public Action OnCounterTick;
        
        public int CurrentLaserAmount { get; private set; }
        public int MaxLaserAmount { get; }
        public Counter Counter { get; }

        private readonly PlayerModel _playerModel;
        private readonly ILaserPool _laserPool;

        public LaserGunModel(float reloadTime, int maxLaserAmount, PlayerModel playerModel, ILaserPool laserPool)
        {
            _playerModel = playerModel;
            MaxLaserAmount = maxLaserAmount;
            _laserPool = laserPool;
            CurrentLaserAmount = MaxLaserAmount;
            Counter = new Counter(reloadTime);
            _playerModel.OnUpdate += Update;
            Counter.OnReloaded += ReloadCompleted;
        }

        private void ReloadCompleted()
        {
            CurrentLaserAmount++;
            OnReloaded?.Invoke();

            if (CurrentLaserAmount < MaxLaserAmount)
                Counter.Reloaded = false;
        }

        private void Update()
        {
            Counter.CounterTick(_playerModel.DeltaTime);
            OnCounterTick?.Invoke();
        }

        public void Fire(UniVector2 laserSpawnPosition, float rotation)
        {
            if (CurrentLaserAmount <= 0)
                return;
            
            _laserPool.Instantiate(laserSpawnPosition, rotation);
            CurrentLaserAmount--;
            Counter.Reloaded = false;
            OnFired?.Invoke();
        }
    }
}