using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _playerRigidbody;

    public float Speed => _speed;
    public Rigidbody PlayerRigidbody => _playerRigidbody;
}
