using UnityEngine;
using UnityEngine.UI;

public class PauseView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Button _buttonPause;
    [SerializeField] private Button _buttonMenu;
    [SerializeField] private Button _buttonResume;

    public Animator AnimatorPause => _animator;
    public Button ButtonPause => _buttonPause;
    public Button ButtonMenu => _buttonMenu;
    public Button ButtonResume => _buttonResume;
}
