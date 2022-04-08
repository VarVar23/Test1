using UnityEngine;

public class PlayerMoveController 
{
    private VariableJoystick _joystick;
    private PlayerView _playerView;
    private Vector3 _direction;

    public PlayerMoveController(PlayerView playerView, VariableJoystick joystick)
    {
        _joystick = joystick;
        _playerView = playerView;
    }

    public void FixedUpdate()
    {
        ChangeDirection();
        Move();
    }
    
    private void ChangeDirection()
    {
        _direction = _playerView.transform.forward * _joystick.Vertical + _playerView.transform.right * _joystick.Horizontal;
    }

    private void Move()
    {
        _playerView.PlayerRigidbody.velocity = _direction * _playerView.Speed * Time.deltaTime;
    }
}
