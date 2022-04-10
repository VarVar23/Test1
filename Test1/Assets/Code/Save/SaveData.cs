using System;

[Serializable]
public class SaveData
{
    public static SaveData Instance;
    public SaveData() => Instance = this;

    public float CountMoney;
    public float PriceUpgradeHp;
    public float PriceUpgradeStrength;
    public float PlayerHp;
    public float PlayerStrength;
    public float EnemyHp;
    public float EnemyStrength;
    public int Level;
    public int LevelUpgradeHp;
    public int LevelUpgradeStrength;
    public float K;
}
