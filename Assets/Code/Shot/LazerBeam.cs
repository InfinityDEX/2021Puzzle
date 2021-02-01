using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBeam : MonoBehaviour
{
    // レーザーの方向(上下)
    enum Dir
    {
        Up = 1,
        Down = -1,
    }
    [SerializeField] Dir m_dir;
    // チャージタイマー
    [SerializeField] float m_charge;
    // レーザーの寿命
    [SerializeField] float m_life;
    // 発射音
    [SerializeField] AudioClip m_lazerSound;
    // 収束粒子エフェクト
    [SerializeField] GameObject m_chargeEffect;


    // Start is called before the first frame update
    void Start()
    {
        // チャージエフェクトを生成
        GameObject effect = Instantiate(m_chargeEffect, transform);

        // 生成された場所からレーザーの方向に向かって伸ばす
        transform.localScale = new Vector3(1, 20, 1);
        transform.Translate(new Vector3(0, (transform.localScale.y / 2.0f + 0.5f) * (int)m_dir, 0));

        // チャージエフェクトの場所をずらす
        effect.transform.position += new Vector3(0, ((int)m_dir * 0.5f) - transform.localScale.y * 0.5f, 0);

        // 音を鳴らす
        var audio = ServiceLocator.Locator.GetAudio();
        audio.PlayOneShot(m_lazerSound, 0.5f);
    }

    private void FixedUpdate()
    {
        // 寿命がゼロなら消滅する
        if(m_life <= 0)
        {
            // 消滅する
            Destroy(this.gameObject);
        }

        // チャージできていなければ
        if (m_charge > 0)
            // チャージ時間を減らす
            m_charge -= Time.fixedDeltaTime;
        else
            // チャージ済みなら寿命を減らす
            m_life -= Time.fixedDeltaTime;
    }
}
