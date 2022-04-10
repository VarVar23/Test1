using UnityEngine;
using Cinemachine;

public class CameraView : MonoBehaviour
{
    [SerializeField] private GameObject _timeline;
    [SerializeField] private GameObject _startCamera;
    [SerializeField] private GameObject _gameCamera;
    [SerializeField] private CinemachineDollyCart _moveObject;
    [SerializeField] private CinemachineVirtualCamera _gameVirtualCamera;

    public GameObject Timeline => _timeline;
    public GameObject StartCamera => _startCamera;
    public GameObject GameCamera => _gameCamera;
    public CinemachineDollyCart MoveObject => _moveObject;
    public CinemachineVirtualCamera GameVirtualCamera => _gameVirtualCamera;
}
