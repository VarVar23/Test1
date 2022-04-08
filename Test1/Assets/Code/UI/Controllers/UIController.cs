using System.Threading.Tasks;

public class UIController 
{
    private UIManagerView _buttonManagerView;

    public UIController(UIManagerView buttonManagerView)
    {
        _buttonManagerView = buttonManagerView;

        Subscribe();
    }
    public void Awake() => GoMenu();

    private void Subscribe()
    {
        _buttonManagerView.StartGame.onClick.AddListener(StartGame);
        _buttonManagerView.ReturnMenuButtonLose.onClick.AddListener(GoMenu);
        _buttonManagerView.ReturnMenuButtonWin.onClick.AddListener(GoMenu);
        _buttonManagerView.ReturnMenuButtonPause.onClick.AddListener(() => WaitEndAnimation(1000));
    }

    private void StartGame()
    {
        _buttonManagerView.StartGame.gameObject.SetActive(false);
        _buttonManagerView.UIMenu.SetActive(false);
        _buttonManagerView.UIPause.SetActive(true);
    }

    private void GoMenu()
    {
        _buttonManagerView.StartGame.gameObject.SetActive(true);
        _buttonManagerView.UIFail.SetActive(false);
        _buttonManagerView.UIPause.SetActive(false);
        _buttonManagerView.UIWin.SetActive(false);
        _buttonManagerView.UIMenu.SetActive(true);
    }

    private async void WaitEndAnimation(int time)
    {
        await Task.Delay(time);
        GoMenu();
    }
}
