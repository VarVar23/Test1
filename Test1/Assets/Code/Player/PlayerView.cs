using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public float Strength = 5;
    public float Hp = 1000;
    [SerializeField] private int _reloadDamageTime;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _playerRigidbody;
    private float _reloadDamageTimeInt;

    public int ReloadDamageTime => _reloadDamageTime;
    public float Speed => _speed;
    public Rigidbody PlayerRigidbody => _playerRigidbody;
}
