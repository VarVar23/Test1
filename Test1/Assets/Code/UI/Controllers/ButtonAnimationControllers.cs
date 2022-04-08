using UnityEngine;

public class ButtonAnimationControllers 
{
    private Vector3 _vectorPosition;

    public ButtonAnimationControllers(ButtonView[] buttonAnimations)
    {
        _vectorPosition = new Vector3(0, 5, 0);

        Subscribe(buttonAnimations);
    }

    private void Subscribe(ButtonView[] buttonAnimations)
    {
        foreach(var button in buttonAnimations)
        {
            button.ButtonUp += ButtonUp;
            button.ButtonDown += ButtonDown;
            button.ButtonClick += ButtonClick;
        }
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

    private void ButtonClick(ButtonView button) => button.ButtonAnimator?.SetTrigger("Click");
}
