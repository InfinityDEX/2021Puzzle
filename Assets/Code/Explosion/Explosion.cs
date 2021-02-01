using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // 爆発音
    [SerializeField] private AudioClip m_expansionSound;
    // エフェクトの寿命
    [SerializeField] float m_lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        // 音を鳴らす
        var audio = ServiceLocator.Locator.GetAudio();
        audio.PlayOneShot(m_expansionSound, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // もし寿命切れなら
        if(m_lifeTime <= 0)
        {
            // 破壊する
            Destroy(this.gameObject);
        }

        // 寿命を減らす
        m_lifeTime -= Time.deltaTime;
    }
}
