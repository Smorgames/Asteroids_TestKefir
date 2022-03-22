using MVC.Logic.Bullet;
using MVC.Logic.Player;
using MVC.View.Bullet;
using MVC.View.Player;
using UnityEngine;

public class Test : MonoBehaviour
{
    public BulletView BulletView;
    public PlayerView PlayerView;
    
    private void Start()
    {
        //BulletTest();
        PlayerTest();
    }

    private void PlayerTest()
    {
        var playerModel = new PlayerModel();
        var playerController = new PlayerController(playerModel, PlayerView);

        playerModel.SetPosition(0f, 0f);
        playerModel.SetRotation(0f);
    }

    private void BulletTest()
    {
        var bulletModel = new BulletModel(2f);
        var bulletController = new BulletController(bulletModel, BulletView);

        bulletModel.SetPosition(0f, 0f);
        BulletView.Shot(Vector2.up);
    }
}