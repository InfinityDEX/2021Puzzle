using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour
{
    // 弾
    [SerializeField] GameObject m_bullet;
    // 連射間の時間
    [SerializeField] float m_interval;
    // タイマー
    float m_timer;
    // Start is called before the first frame update
    void Start()
    {
        // タイマーをリセット
        m_timer = m_interval;
    }

    // Update is called once per frame
    void Update()
    {
        // 発射時間になったら球を打つ
        if(m_timer <= 0)
        {
            Instantiate(m_bullet, transform.position, transform.rotation);
            m_timer = m_interval;
        }
        // タイマーを加算
        m_timer -= Time.deltaTime;
    }
}
