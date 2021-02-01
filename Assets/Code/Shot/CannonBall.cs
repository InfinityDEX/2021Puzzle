using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    // 発射音
    [SerializeField] AudioClip m_shotSound;
    // チャージ時間
    [SerializeField] float m_charge;
    // 弾の大きさ
    [SerializeField] Vector3 m_scale;
    // チャージカウンタ
    private float m_chargeCounter;
    // 弾の所属情報
    BulletAffiliation affiliation;
    // 移動方向
    public Vector3 m_velocity;

    private void Start()
    {
        // 弾の情報を取得する
        affiliation = GetComponent<BulletAffiliation>();

        // 大きさを0にする
        transform.localScale = Vector3.zero;

        // 位置をずらす
        transform.position += m_velocity.normalized * 0.5f;

        // カウンタをセットする
        m_chargeCounter = m_charge;

        // 音を鳴らす
        var audio = ServiceLocator.Locator.GetAudio();
        audio.PlayOneShot(m_shotSound, 0.5f);
    }

    private void FixedUpdate()
    {
        // もしカウンタが0以下なら
        if(m_chargeCounter <= 0)
        {
            // 通常の大きさにする
            transform.localScale = m_scale;
            // 等速移動
            transform.position += m_velocity;
            return;
        }
        else
        {
            // 少しづつ大きくする
            transform.localScale = m_scale * (1.0f - (m_chargeCounter / m_charge));
        }

        // カウンタを減らす
        m_chargeCounter -= Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 接触したブロックのパラメータを取得
        BlockParameter block = null;
        
        // ブロックの情報の取得に失敗したら終了する
        if (!collision.gameObject.TryGetComponent<BlockParameter>(out block))
            return;

        // 敵勢力の弾の接触したら
        if (affiliation.GetTeam() != block.GetTeam())
        {
            // に当たったら消滅する
            Destroy(this.gameObject);
        }
    }
}
