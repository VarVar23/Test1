using System.Threading.Tasks;
using UnityEngine;

public class PlayerDeathController 
{
    private UIManagerView _UIManagerView;
    private PlayerView _playerView;
    private CameraView _cameraView;

    public PlayerDeathController(PlayerView playerView, CameraView cameraView, UIManagerView UIManagerView)
    {
        _UIManagerView = UIManagerView;
        _playerView = playerView;
        _cameraView = cameraView;

        Subscribe();
    }

    private void Subscribe() => _playerView.PlayerDeath += Death;

    private void Death()
    {
        OnPlayerRagdoll();
        _cameraView.GameVirtualCamera.LookAt = _playerView.Spine;
        WaitActivePanel(1500);
    }

    private void OnPlayerRagdoll()
    {
        _playerView.PlayerAnimator.enabled = false;
        _playerView.PlayerCollider.enabled = false;
        _playerView.PlayerRigidbody.isKinematic = true;

        foreach (var rigidbody in _playerView.RagdollRigidbody)
        {
            rigidbody.AddForce(_playerView.transform.forward * -40);
            rigidbody.AddForce(_playerView.transform.up * 50);
            rigidbody.isKinematic = false;
        }

        foreach (var collider in _playerView.RagdollColliders)
        {
            collider.enabled = true;
        }
    }

    private async void WaitActivePanel(int time)
    {
        await Task.Delay(time);
        _UIManagerView.UIFail.SetActive(true);
    }
}
