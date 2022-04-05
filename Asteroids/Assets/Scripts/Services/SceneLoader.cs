using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneLoader
    {
        public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}