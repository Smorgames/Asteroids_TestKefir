using Logic.Interfaces;

namespace Infrastructure.GameDirectory
{
    public interface IGame
    {
        void EnemyDead(IScore iScore);
        void MeteorDead(IScore iScore);
        void GameOver();
        void AddScore(IScore iScore);
    }
}