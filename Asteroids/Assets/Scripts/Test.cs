using Logic.Player;
using UnityEngine;
using View;

public class Test : MonoBehaviour
{
    public PlayerView PlayerView;
    
    private void Start()
    {
        PlayerTest();
    }

    private void PlayerTest()
    {
        var playerModel = new PlayerModel();
        var playerController = new PlayerController(playerModel, PlayerView);

        playerModel.Transform.Position = new UniVector2(0f, 0f);
    }
}