using UnityEngine;
using UniRx;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";

    [SerializeField]
    private PlayerMoveData _playerMoveData;
    
    private Rigidbody2D _rigidbody;
    private PlayerMoveController _playerMoveController;

    private void Start()
    {
        CreateFixedUpdateStream();
    }

    private void CreateFixedUpdateStream()
    {
        Observable.EveryFixedUpdate().Select(_ => Input.GetAxis(HorizontalInput)).Subscribe(input => _playerMoveController.ApplyPlayerMovement(input)).AddTo(this);
    }
}
