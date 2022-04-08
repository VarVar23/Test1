using System.Threading.Tasks;
using UnityEngine;

public class PlayerDamageController 
{
    private PlayerView _playerView;
    private EnemyView _enemyView;
    private bool _damage;

    public PlayerDamageController(PlayerView playerView, EnemyView enemyView)
    {
        _playerView = playerView;
        _enemyView = enemyView;

        Subscribe();
    }

    private void Subscribe()
    {
        _enemyView.PlayerOnTriggerEnterTrigger += StartDamage;
        _enemyView.PlayerOnTriggerExitTrigger += EndDamage;
    }

    private async void StartDamage()
    {
        _damage = true;

        while(_damage)
        {
            Damage();
            await Task.Delay(_playerView.ReloadDamageTime);
        }
    }

    private void EndDamage() => _damage = false;

    private void Damage()
    {
        _enemyView.Hp -= _playerView.Strength;
        Debug.Log(_enemyView.Hp);
    }
}
