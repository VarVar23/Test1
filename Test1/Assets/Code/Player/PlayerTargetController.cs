public class PlayerTargetController
{
    private PlayerView _playerView;
    private EnemyView _enemyView;

    public PlayerTargetController(PlayerView playerView, EnemyView enemyView)
    {
        _playerView = playerView;
        _enemyView = enemyView;
    }

    public void FixedUpdate()
    {
        TargetPlayer();
    }

    private void TargetPlayer()
    {
        _playerView.transform.LookAt(_enemyView.transform);
    }
}
