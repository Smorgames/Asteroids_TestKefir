using Logic.Player;
using Services;
using UnityEngine;
using View;

public class Test : MonoBehaviour
{
    public PlayerView PlayerView;
    
    private void Start()
    {
        var playerController = PlayerInstatiateTest();
        MeteorInstantiateTest();
        EnemyInstantiateTest(playerController);
    }

    private PlayerController PlayerInstatiateTest()
    {
        var playerModel = new PlayerModel();
        var playerController = new PlayerController(playerModel, PlayerView);

        playerModel.Transform.Position = new UniVector2(0f, 0f);

        return playerController;
    }

    private void MeteorInstantiateTest() => 
        GameFactory.CreateMeteor(3f, new UniVector2(10f, 5f), new UniVector2(-1f, -0.5f));

    private void EnemyInstantiateTest(PlayerController playerController) => 
        GameFactory.CreateEnemy(1f, new UniVector2(10f, 10f), playerController.Model);
}