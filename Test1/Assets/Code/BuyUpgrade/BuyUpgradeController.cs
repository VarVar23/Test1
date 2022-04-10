
public class BuyUpgradeController 
{
    private UIDataController _UIdataController;
    private ButtonView[] _buttonViews;
    private DataController _dataController;
    private StartSO _startSO;

    public BuyUpgradeController(UIDataController UIdataController, ButtonView[] buttonViews, DataController dataController, StartSO startSO)
    {
        _UIdataController = UIdataController;
        _buttonViews = buttonViews;
        _dataController = dataController;
        _startSO = startSO;

        Subscribe();
    }

    private void Subscribe()
    {
        foreach(var button in _buttonViews)
        {
            button.ButtonBuyUpgradeHp += BuyUpgradeHp;
            button.ButtonBuyUpgradeStrength += BuyUpgradeStrength;
        }
    }

    private void BuyUpgradeHp()
    {
        var price = SaveData.Instance.PriceUpgradeHp;
        var countMoney = SaveData.Instance.CountMoney;

        if (countMoney < price) return;

        SaveData.Instance.CountMoney -= price;
        SaveData.Instance.PriceUpgradeHp += _startSO.PriceUpgradeHp * _startSO.K;
        SaveData.Instance.LevelUpgradeHp++;

        _dataController.RefreshData();
        _UIdataController.VisualData();
        SaveToJson.Instance.SaveToFile();
    }

    private void BuyUpgradeStrength()
    {
        var price = SaveData.Instance.PriceUpgradeStrength;
        var countMoney = SaveData.Instance.CountMoney;

        if (countMoney < price) return;

        SaveData.Instance.CountMoney -= price;
        SaveData.Instance.PriceUpgradeStrength += _startSO.PriceUpgradeStrength * _startSO.K;
        SaveData.Instance.LevelUpgradeStrength++;

        _dataController.RefreshData();
        _UIdataController.VisualData();
        SaveToJson.Instance.SaveToFile();
    }
}
