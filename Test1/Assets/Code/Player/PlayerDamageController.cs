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
        _enemyView.HpBar.fillAmount = _enemyView.Hp / _enemyView.MaxHp;
        _enemyView.HPText.text = _enemyView.Hp.ToString("N0");

        if (_enemyView.Hp < 0)
        {
            _enemyView.Hp = 0;
            _enemyView.HpBar.fillAmount = 0;
            _enemyView.HPText.text = "0";
            _enemyView.EnemyDeath?.Invoke();
            _damage = false;
        }
    }
}
