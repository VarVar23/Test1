public class RestartSceneController 
{
    private UIDataController _UIdataController;
    private DataController _dataController;
    private UIController _UIcontroller;
    private PlayerView _playerView;

    public RestartSceneController(UIDataController UIdataController, DataController dataController, UIController UIcontroller, PlayerView playerView)
    {
        _UIdataController = UIdataController;
        _dataController = dataController;
        _UIcontroller = UIcontroller;
        _playerView = playerView;
    }

    public void ReStart()
    {
        SaveToJson.Instance.SaveToFile();
        _playerView.transform.position = _playerView.StartPosition;
        _dataController.RefreshData();
        _UIdataController.VisualData();
        _UIcontroller.GoMenu();
    }
}
