using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public float Strength = 5;
    public float MaxHp;
    public float Hp;

    [SerializeField] private Image _hpBar;
    [SerializeField] private Text _hpText;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private int _reloadDamageTime;
    [SerializeField] private float _speed;

    private float _reloadDamageTimeInt;
    private float _hp;

    public Image HpBar => _hpBar;
    public Text HPText => _hpText;
    public int ReloadDamageTime => _reloadDamageTime;
    public float Speed => _speed;
    public Rigidbody PlayerRigidbody => _playerRigidbody;
    public Animator PlayerAnimator => _playerAnimator;
}
