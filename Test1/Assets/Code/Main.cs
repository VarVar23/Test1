using UnityEngine;

public class Main : MonoBehaviour
{
    #region Controllers

    private ButtonAnimationControllers _buttonAnimationControllers;

    #endregion

    private void Awake()
    {
        InitializeAwake();
    }

    private void InitializeAwake()
    {
        _buttonAnimationControllers = new ButtonAnimationControllers(FindObjectsOfType<ButtonView>(true));
    }
}
