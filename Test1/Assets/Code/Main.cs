using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private PauseView _pauseView;
    private ButtonView[] _buttonViews;

    #region Controllers

    private ButtonAnimationControllers _buttonAnimationControllers;

    #endregion

    private void Awake()
    {
        InitializeAwake();
    }

    private void InitializeAwake()
    {
        _buttonViews = FindObjectsOfType<ButtonView>(true);

        _buttonAnimationControllers = new ButtonAnimationControllers(_buttonViews, _pauseView);
    }
}
