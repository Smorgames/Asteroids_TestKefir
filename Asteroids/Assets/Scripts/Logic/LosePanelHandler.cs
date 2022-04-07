using Services;
using Services.SceneLoading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LosePanelHandler : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private Button _restartButton;

    private SceneLoader _sceneLoader;

    public void Construct(SceneLoader sceneLoader)
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