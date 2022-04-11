using Infrastructure.Interfaces;
using UnityEngine;

namespace Infrastructure.Services
{
    public class TimeScaleManager : ITimeScaleManager
    {
        public void SetTimeScale(float scale) => 
            Time.timeScale = scale;
    }
}