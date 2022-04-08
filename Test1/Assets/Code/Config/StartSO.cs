using UnityEngine;


[CreateAssetMenu(fileName = "StartSO", menuName = "Config/StartSO", order = 0)]
public class StartSO : ScriptableObject
{
    public float PriceUpgradeHp;
    public float PriceUpgradeStrength;
    public float PlayerHp;
    public float PlayerStrength;
    public float EnemyHp;
    public float EnemyStrength;
    public float K; // коэффициент
}
