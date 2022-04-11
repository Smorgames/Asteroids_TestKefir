using ModelLogic.Interfaces;

namespace Infrastructure.Interfaces
{
    public interface IGame
    {
        void EnemyDead(IScore iScore);
        void MeteorDead(IScore iScore);
        void GameOver();
    }
}