using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallScene : MonoBehaviour
{
    [SerializeField] string SceneName;

    public void MoveScene()
    {
        // シーンを呼び出す
        SceneManager.LoadScene(SceneName);
    }
}
