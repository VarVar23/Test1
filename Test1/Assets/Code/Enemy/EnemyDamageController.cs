using System.Threading.Tasks;
using UnityEngine;

public class EnemyDamageController
{
    private PlayerView _playerView;
    private EnemyView _enemyView;
    private bool _damage;

    public EnemyDamageController(PlayerView playerView, EnemyView enemyView)
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

        while (_damage)
        {
            Damage();
            await Task.Delay(_playerView.ReloadDamageTime);
        }
    }

    private void EndDamage() => _damage = false;

    private void Damage()
    {
        _playerView.Hp -= _enemyView.Strength;
        _playerView.HpBar.fillAmount = _playerView.Hp / _playerView.MaxHp;
        _playerView.HPText.text = _playerView.Hp.ToString("N0");

        if(_playerView.Hp < 0)
        {
            _playerView.Hp = 0;
            _playerView.HpBar.fillAmount = 0;
            _playerView.HPText.text = "0";
            _playerView.PlayerDeath?.Invoke();
            _damage = false;
        }
    }
}
