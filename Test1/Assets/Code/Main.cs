using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private PauseView _pauseView;
    [SerializeField] private UIManagerView _UImanagerView;
    [SerializeField] private UIMenuView _UImenuView;
    [SerializeField] private CameraView _cameraView;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private MoneyView _moneyView;
    private ButtonView[] _buttonViews;

    [Header("Config")]
    [SerializeField] private StartSO _startSO;
    [SerializeField] private SO _so;

    #region Controllers

    private ButtonAnimationControllers _buttonAnimationControllers;
    private StartCameraMoveController _startCameraMoveController;
    private PlayerMoveController _playerMoveController;
    private PlayerTargetController _playerTargetController;
    private PlayerDamageController _playerDamageController;
    private PlayerAnimatorController _playerAnimatorController;
    private PlayerDeathController _playerDeathController;
    private EnemyTargetController _enemyTargetController;
    private EnemyDamageController _enemyDamageController;
    private EnemyDeathController _enemyDeathController;
    private SaveToJson _saveToJson;
    private SaveData _saveData;
    private StartSettingsController _startSettingsController;
    private DataController _dataController;
    private UIController _UIcontroller;
    private UIDataController _UIdataController;
    private BuyUpgradeController _buyUpgradeController;
    private RestartSceneController _restartScene;

    #endregion

    private void Awake()
    {
        Vector3
        InitializeAwake();

        _UIcontroller.Awake();

       // transform.localPosition;
       // transform.localEulerAngles;
    }

    private void Start()
    {
        StartInitialize();

        _dataController.RefreshData();
        _UIdataController.VisualData();
        _restartScene.OffPlayerRagdoll();
    }

    private void InitializeAwake()
    {
        _buttonViews = FindObjectsOfType<ButtonView>(true);
        _saveData = new SaveData();
        _startSettingsController = new StartSettingsController(_startSO, _playerView, _enemyView, _moneyView);
        _saveToJson = new SaveToJson(_startSettingsController);
        _saveToJson.Awake();
        _saveToJson.LoadFile();

        _dataController = new DataController(_playerView, _enemyView, _startSO);
        _startCameraMoveController = new StartCameraMoveController(_cameraView, _UImanagerView, _playerView);
        _buttonAnimationControllers = new ButtonAnimationControllers(_buttonViews, _pauseView);
        _playerMoveController = new PlayerMoveController(_playerView, _joystick);
        _playerTargetController = new PlayerTargetController(_playerView, _enemyView);
        _playerDamageController = new PlayerDamageController(_playerView, _enemyView);
        _playerAnimatorController = new PlayerAnimatorController(_playerView, _enemyView, _joystick);
        _enemyTargetController = new EnemyTargetController(_playerView, _enemyView);
        _enemyDamageController = new EnemyDamageController(_playerView, _enemyView);

        _UIcontroller = new UIController(_UImanagerView);
        _UIdataController = new UIDataController(_UImenuView, _playerView, _enemyView);
    }

    private void StartInitialize()
    {
        _buyUpgradeController = new BuyUpgradeController(_UIdataController, _buttonViews, _dataController, _startSO);
        _restartScene = new RestartSceneController(_UIdataController, _dataController, _UIcontroller, _playerView, _UImanagerView);
        _playerDeathController = new PlayerDeathController(_playerView, _cameraView, _UImanagerView, _so);
        _enemyDeathController = new EnemyDeathController(_enemyView);
    }

    private void FixedUpdate()
    {
        _playerMoveController?.FixedUpdate();
        _playerTargetController?.FixedUpdate();
        _playerAnimatorController?.FixedUpdate();
        _enemyTargetController?.FixedUpdate();
    }
}
