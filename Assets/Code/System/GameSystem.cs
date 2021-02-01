using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    // ゲームオーバートリガー
    public bool isGameOver { get; private set; }
    // シーン名
    [SerializeField] string m_result;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオーバーなら
        if(this.isGameOver)
        {
            // リザルトシーンを呼び出す
            SceneManager.LoadScene(m_result);
        }
    }

    // ゲームオーバー
    public void GameOver()
    {
        // ゲームオーバーにする
        isGameOver = true;
    }
}
