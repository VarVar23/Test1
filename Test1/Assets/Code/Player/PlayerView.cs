using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public Action PlayerDeath;
    public float Strength = 5;
    public float MaxHp;
    public float Hp;

    [SerializeField] private Image _hpBar;
    [SerializeField] private Text _hpText;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private int _reloadDamageTime;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody[] _ragdollRigidbody;
    [SerializeField] private Collider[] _ragdollColliders;
    [SerializeField] private Transform _spine;

    private Vector3 _startPosition;
    private float _reloadDamageTimeInt;
    private float _hp;

    public Image HpBar => _hpBar;
    public Text HPText => _hpText;
    public int ReloadDamageTime => _reloadDamageTime;
    public float Speed => _speed;
    public Rigidbody PlayerRigidbody => _playerRigidbody;
    public Collider PlayerCollider => _playerCollider;
    public Animator PlayerAnimator => _playerAnimator;
    public Vector3 StartPosition => _startPosition;
    public Rigidbody[] RagdollRigidbody => _ragdollRigidbody;
    public Collider[] RagdollColliders => _ragdollColliders;
    public Transform Spine => _spine; 

    private void Awake() => _startPosition = transform.position;
}
