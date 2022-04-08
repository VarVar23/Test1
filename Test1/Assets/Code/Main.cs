using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private PauseView _pauseView;
    [SerializeField] private UIManagerView _UImanagerView;
    private ButtonView[] _buttonViews;

    #region Controllers

    private ButtonAnimationControllers _buttonAnimationControllers;
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

        _buttonAnimationControllers = new ButtonAnimationControllers(_buttonViews, _pauseView);
        _UIcontroller = new UIController(_UImanagerView);
    }
}
