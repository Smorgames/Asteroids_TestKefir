using Infrastructure.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UIHandlers
{
    public class LosePanelHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private TextMeshProUGUI _scoreTMP;
        [SerializeField] private Button _restartButton;

        private ISceneLoader _sceneLoader;

        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _restartButton.onClick.AddListener(RestartLevel);
        }

        public void ShowLosePanel() =>
            _losePanel.SetActive(true);

        public void SetScore(int score) =>
            _scoreTMP.text = $"SCORE: {score}";

        private void RestartLevel() => 
            _sceneLoader?.ReloadScene();
    }
}