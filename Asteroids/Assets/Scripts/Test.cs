using System.Text;
using MVC.Logic;
using MVC.Logic.Player;
using MVC.View;
using UnityEngine;

public class Test : MonoBehaviour
{
    public PlayerView PlayerView;
    
    private void Start()
    {
        PlayerTest();
        SquareColliderMoveMethodTest();
    }

    private void PlayerTest()
    {
        var playerModel = new PlayerModel();
        var playerController = new PlayerController(playerModel, PlayerView);

        playerModel.Position = new UniVector2(0f, 0f);
    }

    private void SquareColliderMoveMethodTest()
    {
        
    }
}