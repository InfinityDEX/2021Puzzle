using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageChecker : MonoBehaviour
{
    // 自身のブロックのデータ
    private BlockParameter parameter;

    // 爆発エフェクト
    [SerializeField] private GameObject m_explosion;
    // Start is called before the first frame update
    void Start()
    {
        // ブロックパラメーターを取得
        parameter = GetComponent<BlockParameter>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 接触してきた攻撃のパラメータを取得
        BulletAffiliation bullet = null; 

        // ブロックの情報の取得に失敗したら終了する
        if (!collision.gameObject.TryGetComponent<BulletAffiliation>(out bullet))
            return;

        // 敵勢力の弾の接触したら
        if (parameter.GetTeam() != bullet.GetTeam())
        {
            // ダメージを受ける
            parameter.Damage();

            // もしブロックが破壊されていたら
            if(parameter.isDestroy())
            {
                // 爆発エフェクトを出す
                GameObject effect = Instantiate(m_explosion, transform.parent);
                effect.transform.position = transform.position;

                // このオブジェクトを破壊する
                Destroy(this.gameObject);
            }
        }
    }
}
