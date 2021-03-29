using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class PlayerBehaviour : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string ObstacleTag = "Obstacle";
    
    [Header("Components")]
    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Transform PlayerTransform => this.transform;

    private PlayerMoveController _moveController;
    private PlayerShootController _shootController;
    private PlayerHealthController _healthController;
    
    [Inject]
    private void Construct(PlayerMoveController moveController,
                            PlayerShootController shootController,
                            PlayerHealthController healthController)
    {
        _moveController = moveController;
        _shootController = shootController;
        _healthController = healthController;
    }

    private void Start()
    {
        CreateMoveStream();
        CreateShootStream();
        CreateHealthStream();
    }

    private void CreateMoveStream()
    {
        Observable
            .EveryFixedUpdate()
            .Select(_ => Input.GetAxis(HorizontalInput))
            .Subscribe(input => _moveController.ApplyPlayerMovement(input))
            .AddTo(this);
    }

    private void CreateShootStream()
    {
        
    }

    private void CreateHealthStream()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(collision => collision.CompareTag(ObstacleTag))
            .Subscribe(collision => _healthController.TriggerCollisionWithObstacle(collision))
            .AddTo(this);
    }
}
