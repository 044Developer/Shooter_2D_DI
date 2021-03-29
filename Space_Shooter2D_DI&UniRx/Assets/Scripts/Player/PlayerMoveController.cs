using UnityEngine;
using Zenject;

public class PlayerMoveController 
{
    private PlayerMoveData _playerMoveData;
    private Transform _playerTransform;
    private Rigidbody2D _rigidbody;
    
    [Inject]
    public PlayerMoveController(PlayerMoveData playerMoveData, PlayerBehaviour playerBehaviour)
    {
        _playerMoveData = playerMoveData;
        _playerTransform = playerBehaviour.PlayerTransform;
        _rigidbody = playerBehaviour.Rigidbody2D;
    }

    public void ApplyPlayerMovement(float horizontalInput)
    {
        var position = _playerTransform.position;
        
        _rigidbody.MovePosition(new Vector2(position.x + horizontalInput * _playerMoveData.SideMoveSpeed * Time.deltaTime, position.y));
    }
}
