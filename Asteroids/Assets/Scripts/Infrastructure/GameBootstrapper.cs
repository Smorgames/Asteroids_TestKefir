using Infrastructure.GameDirectory;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            var game = new Game();
        }
    }
}