using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoading
{
    public class SceneLoader : ISceneLoader
    {
        public void ReloadScene()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}