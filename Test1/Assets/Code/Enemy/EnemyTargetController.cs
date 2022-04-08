public class EnemyTargetController
{
    private PlayerView _playerView;
    private EnemyView _enemyView;

    public EnemyTargetController(PlayerView playerView, EnemyView enemyView)
    {
        _playerView = playerView;
        _enemyView = enemyView;
    }

    public void FixedUpdate()
    {
        TargetEnemy();
    }

    private void TargetEnemy()
    {
        _enemyView.transform.LookAt(_playerView.transform);
    }
}
