using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerDeathController 
{
    private UIManagerView _UIManagerView;
    private PlayerView _playerView;
    private CameraView _cameraView;
    private BonesSO _boneSO;

    public PlayerDeathController(PlayerView playerView, CameraView cameraView, UIManagerView UIManagerView, BonesSO boneSo)
    {
        _boneSO = boneSo;
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
        WaitStandUp(2000);
        WaitActivePanel(3000);
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

    private async void WaitStandUp(int time)
    {
        await Task.Delay(time);
        BoneVelocityReset();
        _playerView.RagdollParent.transform.parent = null;
        _playerView.transform.position = _playerView.RagdollParent.transform.position;
        _playerView.RagdollParent.transform.parent = _playerView.transform;

        _playerView.StartCoroutine(ResetPosition());
    }

    private void BoneVelocityReset()
    {
        foreach (var rigidbody in _playerView.RagdollRigidbody)
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    private IEnumerator ResetPosition()
    {

        foreach(var r in _playerView.RagdollRigidbody)
        {
            r.isKinematic = true;
        }

        foreach (var c in _playerView.RagdollColliders)
        {
            c.enabled = false;
        }

        Vector3[] startPos = new Vector3[11];
        Quaternion[] startRot = new Quaternion[11];


        while(true)
        {
            for (int i = 0; i < _boneSO.BonesPosition.Length; i++)
            {

                _boneSO.Bones[i].transform.localPosition = Vector3.Lerp(_boneSO.Bones[i].transform.localPosition, _boneSO.BonesPosition[i], 0.001f);
                _boneSO.Bones[i].transform.localRotation = Quaternion.Lerp(_boneSO.Bones[i].transform.localRotation, _boneSO.BonesRotation[i], 0.001f);

                if (CheckEndPosition(_boneSO.Bones, _boneSO.BonesPosition)) yield break;
            }
            yield return null; 
        }
    }

    private bool CheckEndPosition(Rigidbody[] posCurrent, Vector3[] posEnd)
    {
        for(int i = 0; i < posCurrent.Length; i++)
        {
            if(posCurrent[i].transform.localPosition != posEnd[i])
            {
                return false;
            }
        }

        return true;
    }
}
