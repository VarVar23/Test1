using UnityEngine;
using UnityEngine.UI;

public class UIManagerView : MonoBehaviour
{
    [SerializeField] private Button _returnMenuButtonPause;
    [SerializeField] private Button _returnMenuButtonLose;
    [SerializeField] private Button _returnMenuButtonWin;
    [SerializeField] private Button _startGame;
    [SerializeField] private GameObject _UIWin;
    [SerializeField] private GameObject _UIFail;
    [SerializeField] private GameObject _UIPause;
    [SerializeField] private GameObject _UIMenu;

    public Button ReturnMenuButtonPause => _returnMenuButtonPause;
    public Button ReturnMenuButtonLose => _returnMenuButtonLose;
    public Button ReturnMenuButtonWin => _returnMenuButtonWin;
    public Button StartGame => _startGame;
    public GameObject UIWin => _UIWin;
    public GameObject UIFail => _UIFail;
    public GameObject UIPause => _UIPause;
    public GameObject UIMenu => _UIMenu;
}
