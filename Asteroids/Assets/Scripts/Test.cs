using Logic.Player;
using Services;
using UnityEngine;
using View;

public class Test : MonoBehaviour
{
    public PlayerView PlayerView;
    
    private void Start()
    {
        PlayerTest();
        MeteorInstantiateTest();
    }

    private void PlayerTest()
    {
        var playerModel = new PlayerModel();
        var playerController = new PlayerController(playerModel, PlayerView);

        playerModel.Transform.Position = new UniVector2(0f, 0f);
    }

    private void MeteorInstantiateTest() => 
        GameFactory.CreateMeteor(3f, new UniVector2(10f, 5f), new UniVector2(-1f, -0.5f));
}