public class PlayerAnimatorController
{
    private VariableJoystick _joystick;
    private PlayerView _playerView;
    private EnemyView _enemyView;

    public PlayerAnimatorController(PlayerView playerView, EnemyView enemyView, VariableJoystick joystick)
    {
        _playerView = playerView;
        _enemyView = enemyView;
        _joystick = joystick;

        Subscribe();
    }

    private void Subscribe()
    {
        _enemyView.PlayerOnTriggerEnterTrigger += AttackAnimation;
        _enemyView.PlayerOnTriggerExitTrigger += DeattackAnimation;
    }

    public void FixedUpdate()
    {
        _playerView.PlayerAnimator.SetFloat("Horizontal", _joystick.Horizontal);
        _playerView.PlayerAnimator.SetFloat("Vertical", _joystick.Vertical);
    }

    private void AttackAnimation()
    {
        _playerView.PlayerAnimator.SetBool("Attack", true);
    }

    private void DeattackAnimation()
    {
        _playerView.PlayerAnimator.SetBool("Attack", false);
    }
}
