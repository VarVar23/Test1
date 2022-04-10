using UnityEngine;

public class EnemyDeathController
{
    private EnemyView _enemyView;

    public EnemyDeathController(EnemyView enemyView)
    {
        _enemyView = enemyView;

        Subscribe();
    }

    private void Subscribe() => _enemyView.EnemyDeath += Death;

    private void Death()
    {
        Debug.Log("smertb");
    }
}
