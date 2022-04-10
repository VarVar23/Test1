using UnityEngine;
using UnityEngine.UI;

public class UIMenuView : MonoBehaviour
{
    [SerializeField] private Text _levelHp;
    [SerializeField] private Text _priceHp;
    [SerializeField] private Text _levelStrength;
    [SerializeField] private Text _priceStrength;
    [SerializeField] private Text _countMoney;
    [SerializeField] private Text _level;

    public Text LevelHp => _levelHp;
    public Text PriceHp => _priceHp;
    public Text LevelStrength => _levelStrength;
    public Text PriceStrength => _priceStrength;
    public Text CountMoney => _countMoney;
    public Text Level => _level;
}
