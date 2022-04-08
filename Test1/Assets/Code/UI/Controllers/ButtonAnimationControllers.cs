using UnityEngine;

public class ButtonAnimationControllers 
{
    private Vector3 _vectorPosition;
    private PauseView _pauseView;

    public ButtonAnimationControllers(ButtonView[] buttonAnimations, PauseView pauseView)
    {
        _pauseView = pauseView;
        _vectorPosition = new Vector3(0, 5, 0);

        Subscribe(buttonAnimations);
    }

    private void Subscribe(ButtonView[] buttonAnimations)
    {
        foreach(var button in buttonAnimations)
        {
            button.ButtonUp += ButtonUp;
            button.ButtonDown += ButtonDown;
        }

        _pauseView.ButtonPause.onClick.AddListener(() => ButtonPause(true));
        _pauseView.ButtonResume.onClick.AddListener(() => ButtonPause(false));
    }

    private void ButtonUp(ButtonView button)
    {
        button.ImageButton.sprite = button.SpriteButtonUp;
        button.RectTransformButton.localPosition += _vectorPosition;
    }

    private void ButtonDown(ButtonView button)
    {
        button.ImageButton.sprite = button.SpriteButtonDown;
        button.RectTransformButton.localPosition -= _vectorPosition;
    }

    private void ButtonPause(bool pause)
    {
        _pauseView.AnimatorPause.SetBool("Pause", pause);
    }
}
