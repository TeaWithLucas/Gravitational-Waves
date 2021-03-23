using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostSceneUtils : MonoBehaviour
{
    public void LoadGameScene()
    {
        MySceneManager.SetSceneArgument("GameView", "IsHost", true);
        SceneManager.LoadSceneAsync("GameView");
    }
}
