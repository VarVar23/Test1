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

    #region Controllers

    private ButtonAnimationControllers _buttonAnimationControllers;
    private StartCameraMoveController _startCameraMoveController;
    private PlayerMoveController _playerMoveController;
    private PlayerTargetController _playerTargetController;
    private PlayerDamageController _playerDamageController;
    private PlayerAnimatorController _playerAnimatorController;
    private EnemyTargetController _enemyTargetController;
    private EnemyDamageController _enemyDamageController;
    private SaveToJson _saveToJson;
    private SaveData _saveData;
    private StartSettingsController _startSettingsController;
    private DataController _dataController;
    private UIController _UIcontroller;
    private UIDataController _UIdataController;
    private BuyUpgradeController _buyUpgradeController;

    #endregion

    private void Awake()
    {
        InitializeAwake();

        _UIcontroller.Awake();
    }

    private void Start()
    {
        StartInitialize();

        _dataController.RefreshData();
        _UIdataController.VisualData();
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
        _startCameraMoveController = new StartCameraMoveController(_cameraView, _UImanagerView);
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
    }

    private void FixedUpdate()
    {
        _playerMoveController?.FixedUpdate();
        _playerTargetController?.FixedUpdate();
        _playerAnimatorController?.FixedUpdate();
        _enemyTargetController?.FixedUpdate();
    }
}
