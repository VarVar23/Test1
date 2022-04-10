public class RestartSceneController 
{
    private UIDataController _UIdataController;
    private DataController _dataController;
    private UIController _UIcontroller;
    private UIManagerView _UImanagerView;
    private PlayerView _playerView;

    public RestartSceneController(UIDataController UIdataController, DataController dataController, UIController UIcontroller, PlayerView playerView, UIManagerView UImanagerView)
    {
        _UIdataController = UIdataController;
        _dataController = dataController;
        _UIcontroller = UIcontroller;
        _UImanagerView = UImanagerView;
        _playerView = playerView;

        Subscribe();
    }

    private void Subscribe()
    {
        _UImanagerView.ReturnMenuButtonLose.onClick.AddListener(ReStart);
    }

    public void ReStart()
    {
        SaveToJson.Instance.SaveToFile();
        _playerView.transform.position = _playerView.StartPosition;
        OffPlayerRagdoll();
        _dataController.RefreshData();
        _UIdataController.VisualData();
        _UIcontroller.GoMenu();
    }

    public void OffPlayerRagdoll()
    {
        _playerView.PlayerAnimator.enabled = true;
        _playerView.PlayerCollider.enabled = true;
        _playerView.PlayerRigidbody.isKinematic = false;

        foreach (var rigidbody in _playerView.RagdollRigidbody)
        {
            rigidbody.isKinematic = true;
        }

        foreach (var collider in _playerView.RagdollColliders)
        {
            collider.enabled = false;
        }
    }
}
