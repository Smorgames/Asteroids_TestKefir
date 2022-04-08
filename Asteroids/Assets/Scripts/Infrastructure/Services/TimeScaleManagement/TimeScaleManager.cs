using UnityEngine;

namespace Infrastructure.Services.TimeScaleManagement
{
    public class TimeScaleManager : ITimeScaleManager
    {
        public void SetTimeScale(float scale) => 
            Time.timeScale = scale;
    }
}