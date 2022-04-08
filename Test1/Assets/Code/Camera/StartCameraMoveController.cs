using UnityEngine;

public class StartCameraMoveController
{
    private CameraView _cameraView;
    private UIManagerView _UIManagerView;
    public static StartCameraMoveController Instance;

    public StartCameraMoveController(CameraView cameraView, UIManagerView UIManagerView)
    {
        Instance = this;
        _UIManagerView = UIManagerView;
        _cameraView = cameraView;

        Subscribe();
    }

    private void Subscribe()
    {
        _UIManagerView.StartGame.onClick.AddListener(StartMove);
    }

    private void StartMove() => _cameraView.Timeline.gameObject.SetActive(true);

    public void EndMove()
    {
        _cameraView.Timeline.gameObject.SetActive(false);
        _cameraView.GameCamera.SetActive(false);
        _cameraView.MoveObject.m_Position = 0;
        _cameraView.MoveObject.transform.position = new Vector3(0, 2, 0);
        _cameraView.StartCamera.SetActive(true);
    }
}
