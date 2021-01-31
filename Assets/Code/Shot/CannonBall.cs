using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    // 発射音
    [SerializeField] AudioClip m_shotSound;
    // 弾の所属情報
    BulletAffiliation affiliation;
    // 移動方向
    public Vector3 m_velocity;

    private void Start()
    {
        // 弾の情報を取得する
        affiliation = GetComponent<BulletAffiliation>();

        // 音を鳴らす
        var audio = ServiceLocator.Locator.GetAudio();
        audio.volume = 0.5f;
        audio.PlayOneShot(m_shotSound);
    }

    private void FixedUpdate()
    {
        // 等速移動
        transform.position += m_velocity;
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
