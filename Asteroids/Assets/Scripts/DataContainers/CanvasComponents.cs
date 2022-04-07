using Logic;
using UnityEngine;

namespace DataContainers
{
    public class CanvasComponents : MonoBehaviour
    {
        public LosePanelHandler LosePanelHandler => _losePanelHandler;
        public PlayerIndicatorHandler PlayerIndicatorHandler => _playerIndicatorHandler; 
        
        [SerializeField] private LosePanelHandler _losePanelHandler;
        [SerializeField] private PlayerIndicatorHandler _playerIndicatorHandler;
    }
}