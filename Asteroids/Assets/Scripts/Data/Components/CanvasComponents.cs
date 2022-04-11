using Gameplay.UIHandlers;
using UnityEngine;

namespace Data.Components
{
    public class CanvasComponents : MonoBehaviour
    {
        public LosePanelHandler LosePanelHandler => _losePanelHandler;
        public PlayerIndicatorHandler PlayerIndicatorHandler => _playerIndicatorHandler; 
        
        [SerializeField] private LosePanelHandler _losePanelHandler;
        [SerializeField] private PlayerIndicatorHandler _playerIndicatorHandler;
    }
}