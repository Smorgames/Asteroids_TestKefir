using System;

namespace Logic
{
    public class Counter
    {
        public Action OnReloaded;
        
        public bool Reloaded { get; set; } = true;
        public float CurrentReloadTime { get; private set; }
        public float ReloadTime { get; }

        public Counter(float reloadTime) => 
            ReloadTime = reloadTime;
        
        public void CounterTick(float deltaTime)
        {
            if (Reloaded)
                return;

            CurrentReloadTime += deltaTime;

            if (ReloadingCompleted())
            {
                Reloaded = true;
                CurrentReloadTime = 0f;
                OnReloaded?.Invoke();
            }
        }

        private bool ReloadingCompleted() => CurrentReloadTime >= ReloadTime;
    }
}