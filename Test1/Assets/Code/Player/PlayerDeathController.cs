using UnityEngine;

public class PlayerDeathController 
{
    private RestartSceneController _restartSceneController;
    private PlayerView _playerView;

    public PlayerDeathController(PlayerView playerView, RestartSceneController restartSceneController)
    {
        _restartSceneController = restartSceneController;
        _playerView = playerView;

        Subscribe();
    }

    private void Subscribe() => _playerView.PlayerDeath += Death;

    private void Death()
    {
        _restartSceneController.ReStart();
        Debug.Log("smertb");
    }
}
