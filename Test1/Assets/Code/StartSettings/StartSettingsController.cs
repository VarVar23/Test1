using UnityEngine;

public class StartSettingsController 
{
    private StartSO _startSO;
    private PlayerView _playerView;
    private EnemyView _enemyView;
    private MoneyView _moneyView;

    public StartSettingsController(StartSO startSO, PlayerView playerView, EnemyView enemyView, MoneyView moneyView)
    {
        _startSO = startSO;
        _playerView = playerView;
        _enemyView = enemyView;
        _moneyView = moneyView;
    }

    public void StartSettings()
    {
        SaveData.Instance.PriceUpgradeStrength = _startSO.PriceUpgradeHp;
        SaveData.Instance.PriceUpgradeHp = _startSO.PriceUpgradeStrength;
        SaveData.Instance.PlayerHp = _startSO.PlayerHp;
        SaveData.Instance.PlayerStrength = _startSO.PlayerStrength;
        SaveData.Instance.EnemyHp = _startSO.EnemyHp;
        SaveData.Instance.EnemyStrength = _startSO.EnemyStrength;
        SaveData.Instance.K = _startSO.K;
        SaveData.Instance.CountMoney = 2000;
        SaveData.Instance.Level = 1;
        SaveData.Instance.LevelUpgradeHp = 1;
        SaveData.Instance.LevelUpgradeStrength = 1;

        _playerView.Hp = _startSO.PlayerHp;
        _playerView.Strength = _startSO.PlayerStrength;
        _enemyView.Hp = _startSO.EnemyHp;
        _enemyView.Strength = _startSO.EnemyStrength;
        _moneyView.CountMoney.text = "0";
        _moneyView.PriceUpgradeHp.text = $"{_startSO.PriceUpgradeHp}";
        _moneyView.PriceUpgradeStrength.text = $"{_startSO.PriceUpgradeStrength}";
    }
}
