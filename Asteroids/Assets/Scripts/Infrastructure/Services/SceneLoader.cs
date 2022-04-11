using Infrastructure.Interfaces;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ITimeScaleManager _timeScaleManager;

        public SceneLoader(ITimeScaleManager timeScaleManager)
        {
            _timeScaleManager = timeScaleManager;
        }

        public void ReloadScene()
        {
            _timeScaleManager.SetTimeScale(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}