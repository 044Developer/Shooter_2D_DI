
using UnityEngine;
using Zenject;

public class PlayerHealthController : IInitializable
{
    private PlayerHealthData _playerHealthData;
    private int _currentHealthCount;
    
    [Inject]
    public PlayerHealthController(PlayerHealthData playerHealthData)
    {
        _playerHealthData = playerHealthData;
    }
    
    public void Initialize()
    {
        InitializePlayerHealth();
    } 
    
    public void TriggerCollisionWithObstacle(Collider2D collision)
    {
        DecreaseHealthCount();
        ObjectPoolEvents.OnReturnObstacleToPool(collision.gameObject);
    }
    
    private void InitializePlayerHealth()
    {
        _currentHealthCount = _playerHealthData.PlayerMaxHealth;
        HUDEvents.OnUpdateHealthHUD(_currentHealthCount);
    }
    
    private void DecreaseHealthCount()
    {
        _currentHealthCount--;

        if (_currentHealthCount >= 0)
        {
            HUDEvents.OnUpdateHealthHUD(_currentHealthCount);
        }
        else
        {
            PlayerEvents.OnPlayerDied();
        }
    }
}
