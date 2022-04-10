public class UIDataController
{
    private UIMenuView _UImenuView;
    private PlayerView _playerView;
    private EnemyView _enemyView;

    public UIDataController(UIMenuView UImenuView, PlayerView playerView, EnemyView enemyView)
    {
        _UImenuView = UImenuView;   
        _playerView = playerView;
        _enemyView = enemyView;
    }

    public void VisualData()
    {
        _playerView.HPText.text = _playerView.Hp.ToString();
        _enemyView.HPText.text = _enemyView.Hp.ToString();
        _playerView.HpBar.fillAmount = 1;
        _enemyView.HpBar.fillAmount = 1;

        _UImenuView.CountMoney.text = SaveData.Instance.CountMoney.ToString();
        _UImenuView.Level.text = "LEVEL " + SaveData.Instance.Level.ToString();
        _UImenuView.LevelHp.text = "LV. " + SaveData.Instance.LevelUpgradeHp.ToString();
        _UImenuView.LevelStrength.text = "LV. " + SaveData.Instance.LevelUpgradeStrength.ToString();
        _UImenuView.PriceHp.text = SaveData.Instance.PriceUpgradeHp.ToString();
        _UImenuView.PriceStrength.text = SaveData.Instance.PriceUpgradeStrength.ToString();
    }
}
