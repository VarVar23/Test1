using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    public RectTransform RectTransformButton => _rectTransformButton;
    public Image ImageButton => _imageButton;
    public Sprite SpriteButtonDown => _spriteButtonDown;
    public Sprite SpriteButtonUp => _spriteButtonUp;
    public Animator ButtonAnimator => _buttonAnimator;

    [SerializeField] private RectTransform _rectTransformButton;
    [SerializeField] private Image _imageButton;
    [SerializeField] private Sprite _spriteButtonDown;
    [SerializeField] private Sprite _spriteButtonUp;
    [SerializeField] private Animator _buttonAnimator;


    public Action<ButtonView> ButtonUp;
    public Action<ButtonView> ButtonDown;
    public Action<ButtonView> ButtonClick;

    public void ButtonUpMethod() => ButtonUp?.Invoke(this);
    public void ButtonDownMethod() => ButtonDown?.Invoke(this);
    public void ButtonClickMethod() => ButtonClick?.Invoke(this);
}
