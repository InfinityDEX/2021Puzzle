using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    // シングルトン
    public static ServiceLocator Locator { get; private set; }

    /// 共有アイテム
    // サウンドマネージャ
    [SerializeField] AudioSource AudioSource;
    [SerializeField] GameSystem GameSystem;
    [SerializeField] BlockGenerator BlockGenerator;    

    void Awake()
    {
        if (Locator == null)
            Locator = this;
        else
            Debug.LogError("サービスロケータ ヲ”2回”生成シタナッッ！！");
    }

    // オーディオソースを渡す
    public AudioSource GetAudio()
    {
        return AudioSource;
    }

    // ゲームシステムを渡す
    public GameSystem GetSystem()
    {
        return GameSystem;
    }

    // ブロックジェネレーターを渡す
    public BlockGenerator GetBlockGenerator()
    {
        return BlockGenerator;
    }
}
