using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private PauseView _pauseView;
    [SerializeField] private UIManagerView _UImanagerView;
    [SerializeField] private CameraView _cameraView;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private VariableJoystick _joystick;
    private ButtonView[] _buttonViews;

    #region Controllers

    private ButtonAnimationControllers _buttonAnimationControllers;
    private StartCameraMoveController _startCameraMoveController;
    private PlayerMoveController _playerMoveController;
    private PlayerTargetController _playerTargetController;
    private EnemyTargetController _enemyTargetController;
    private UIController _UIcontroller;

    #endregion

    private void Awake()
    {
        InitializeAwake();

        _UIcontroller.Awake();
    }

    private void InitializeAwake()
    {
        _buttonViews = FindObjectsOfType<ButtonView>(true);

        _startCameraMoveController = new StartCameraMoveController(_cameraView, _UImanagerView);
        _buttonAnimationControllers = new ButtonAnimationControllers(_buttonViews, _pauseView);
        _playerMoveController = new PlayerMoveController(_playerView, _joystick);
        _playerTargetController = new PlayerTargetController(_playerView, _enemyView);
        _enemyTargetController = new EnemyTargetController(_playerView, _enemyView);
        _UIcontroller = new UIController(_UImanagerView);
    }

    private void FixedUpdate()
    {
        _playerMoveController?.FixedUpdate();
        _playerTargetController?.FixedUpdate();
        _enemyTargetController?.FixedUpdate();
    }
}
