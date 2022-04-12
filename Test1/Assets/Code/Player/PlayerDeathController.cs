using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerDeathController 
{
    private UIManagerView _UIManagerView;
    private PlayerView _playerView;
    private CameraView _cameraView;
    private SO _so;

    public PlayerDeathController(PlayerView playerView, CameraView cameraView, UIManagerView UIManagerView, SO so)
    {
        _so = so;
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
        WaitActivePanel(1000);
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
        BoneVelocityReset();
        _playerView.RagdollParent.transform.parent = null;
        _playerView.transform.position = _playerView.RagdollParent.transform.position;
        _playerView.RagdollParent.transform.parent = _playerView.transform;

        _playerView.StartCoroutine(ResetPosition());
        //Восстание из регдолла
        //_UIManagerView.UIFail.SetActive(true);
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
        for(int i = 0; i < 60; i++)
        {
            yield return null; 
        }

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

        //for (int i = 0; i < _so.BonePositions.Length; i++)
        //{
        //    startPos[i] = _so.Bones[i].localPosition;
        //    startRot[i] = _so.Bones[i].localRotation;
        //}


        //for(float j = 0; j < 100f; j++)
        //{
        var time = 0f;

        while(true)
        {
            for (int i = 0; i < _so.Pos2.Length; i++)
            {

                _so.Bones[i].transform.localPosition = Vector3.Lerp(_so.Bones[i].transform.localPosition, _so.Pos2[i], 0.001f);
                _so.Bones[i].transform.localRotation = Quaternion.Lerp(_so.Bones[i].transform.localRotation, _so.Rot2[i], 0.001f);

                if (CheckEndPosition(_so.Bones, _so.Pos2))
                {
                    //PlayAnimation
                    yield break;
                }

            }
            yield return null; 
        }



        //}


        //Debug.Log("ss");
        //for(float j = 0; j < 60f; j += Time.deltaTime)
        //{
        //    for (int i = 0; i < _playerView.RagdollRigidbody.Length; i++)
        //    {
        //        _playerView.RagdollRigidbody[i].transform.localPosition = Vector3.Lerp
        //            (_playerView.RagdollRigidbody[i].transform.localPosition, _so.BonePositions[i], j / 60f);
        //        yield return null;
        //    }

        //    for (int i = 0; i < _playerView.RagdollRigidbody.Length; i++)
        //    {
        //        _playerView.RagdollRigidbody[i].transform.localRotation = Quaternion.Lerp
        //            (_playerView.RagdollRigidbody[i].transform.localRotation, _so.BoneRotations[i], j / 60f);
        //        yield return null;
        //    }
        //}
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
