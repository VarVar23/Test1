public class DataController 
{
    private PlayerView _playerView;
    private EnemyView _enemyView;
    private StartSO _startSO;

    public DataController(PlayerView playerView, EnemyView enemyView, StartSO startSO)
    {
        _playerView = playerView;
        _enemyView = enemyView;
        _startSO = startSO;
    }

    public void RefreshData()
    {
        SetDataPlayer();
        SetDataEnemy();
    }

    private void SetDataPlayer()
    {
        if (SaveData.Instance.LevelUpgradeStrength == 1) _playerView.Strength = _startSO.PlayerStrength;
        else _playerView.Strength = SaveData.Instance.PlayerStrength * _startSO.PlayerStrength * _startSO.K * (SaveData.Instance.LevelUpgradeStrength - 1);

        if (SaveData.Instance.LevelUpgradeHp == 1) _playerView.MaxHp = _startSO.PlayerHp;
        else _playerView.MaxHp = SaveData.Instance.PlayerHp + _startSO.PlayerHp * _startSO.K * (SaveData.Instance.LevelUpgradeHp - 1);
       
        _playerView.Hp = _playerView.MaxHp;
    }

    private void SetDataEnemy()
    {
        if (SaveData.Instance.Level == 1)
        {
            _enemyView.Strength = _startSO.EnemyStrength;
            _enemyView.MaxHp = _startSO.EnemyHp;
        }
        else
        {
            _enemyView.Strength = SaveData.Instance.EnemyStrength + _startSO.EnemyStrength * _startSO.K * (SaveData.Instance.Level - 1);
            _enemyView.MaxHp = SaveData.Instance.EnemyHp + _startSO.EnemyHp * _startSO.K * (SaveData.Instance.Level - 1);
        }

        _enemyView.Hp = _enemyView.MaxHp;
    }
}
