using UnityEngine;

public class StartCameraMoveController
{
    private PlayerView _playerView;
    private CameraView _cameraView;
    private UIManagerView _UIManagerView;
    public static StartCameraMoveController Instance;

    public StartCameraMoveController(CameraView cameraView, UIManagerView UIManagerView, PlayerView playerView)
    {
        Instance = this;
        _playerView = playerView;
        _UIManagerView = UIManagerView;
        _cameraView = cameraView;

        Subscribe();
    }

    private void Subscribe()
    {
        _UIManagerView.StartGame.onClick.AddListener(StartMove);
    }

    private void StartMove()
    {
        _cameraView.Timeline.gameObject.SetActive(true);
        _cameraView.GameVirtualCamera.LookAt = _playerView.transform;
    }


    public void EndMove()
    {
        _cameraView.Timeline.gameObject.SetActive(false);
        _cameraView.GameCamera.SetActive(false);
        _cameraView.MoveObject.m_Position = 0;
        _cameraView.MoveObject.transform.position = new Vector3(0, 2, 0);
        _cameraView.StartCamera.SetActive(true);
    }
}
