using UnityEngine;
using UnityEngine.UI;


public class MoneyView : MonoBehaviour
{
    [SerializeField] private Text _priceUpgradeHp;
    [SerializeField] private Text _priceUpgradeStrength;
    [SerializeField] private Text _countMoney;
    [SerializeField] private Text _countMoneyWin;
    [SerializeField] private Text _countMoneyFail;

    public Text PriceUpgradeHp => _priceUpgradeHp;
    public Text PriceUpgradeStrength => _priceUpgradeStrength;
    public Text CountMoney => _countMoney;
    public Text CountMoneyWin => _countMoneyWin;
    public Text CountMoneyFail => _countMoneyFail;
}
