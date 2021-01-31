using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 移動制御
public class MovementObject : MonoBehaviour
{
    // Grid
    public Vector2Int m_grid;
    // 移動にかかるフレーム
    public int m_moveFrame;
    // 行先
    private Vector3 m_dest;
    // 移動方向
    public Vector2Int Dir { get; private set; }
    // 移動命令を受け付けられるか？
    private bool canAccept;

    private void Start()
    {
        // 受付可能
        canAccept = true;
        // 目的地は現在地
        m_dest = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 受付済みなら
        if(!canAccept)
        {
            // 移動量
            Vector3 movement = new Vector3(Dir.x / (float)m_moveFrame, Dir.y / (float)m_moveFrame);
            // 移動する
            transform.position += movement;

            // 通り過ぎたか目的地なら
            if(
                (m_dest - transform.position).normalized.x != Dir.x ||
                (m_dest - transform.position).normalized.y != Dir.y
                )
            {
                // 目的地に座標を合わせる
                transform.position = m_dest;
                // 移動命令を受け付ける
                canAccept = true;
            }
        }
    }
    // 移動できるか？
    public bool CanMove()
    {
        // 命令ができれば移動できる
        return canAccept;
    }
    // 移動
    public void Move(int x, int y)
    {
        Move(new Vector2Int(x, y));
    }
    public void Move(Vector2Int dir)
    {
        // 受付できないなら処理しない
        if (!canAccept)
            return;
        // 方向をセット
        Dir = dir;
        // グリッド分だけ移動
        m_dest = transform.position + new Vector3(Dir.x * m_grid.x, Dir.y * m_grid.y);
        // 受付できなくする
        canAccept = false;
    }
}
