using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.SceneLoading
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