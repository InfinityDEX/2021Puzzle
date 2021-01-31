using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    // フィールドのグリッドの大きさ
    [SerializeField] public Vector2 m_grid;
    // フィールド内のブロックデータ
    public List<List<BlockParameter>> Blocks { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        // データの初期化
        Blocks = new List<List<BlockParameter>>();

        //// 空のデータコンテナを作成
        //for (int i = 0; i < m_grid.x; i++)
        //{
        //    // 横のラインを定義
        //    List<BlockParameter> horizon = new List<BlockParameter>();
        //    for (int j = 0; j < m_grid.y; j++)
        //    {
        //        // 空のデータを代入
        //        horizon.Add(null);
        //    }
        //    // フィールドのデータに代入
        //    m_blocks.Add(horizon);
        //}
    }

    // ブロックが存在するか確認する
    public BlockParameter CheckBlock(Vector2Int pos)
    {
        return CheckBlock(pos.x, pos.y);
    }
    public BlockParameter CheckBlock(int horizon, int vertical)
    {
        // 指定した住所にブロックがあれば
        if(Blocks[vertical][horizon] != null)
            return Blocks[vertical][horizon];
        // なければnullを返す
        else
            return null;
    }

    // ブロック移動の結果
    public enum MoveInfo
    {
        // 移動出来た
        SUCCESS,
        // ブロックが存在しない
        NOTHING,
        // パワー不足
        MSSINGHINGPOWER,
        // 使われている
        USED,
        // フィールド外だった
        OUTSIDE,
    }

    // 住所の移動(posAからposBへ)
    public MoveInfo MoveBlock(Vector2Int posA, Vector2Int posB, int power)
    {
        // 移動先がフィールドの外を指している
        if (m_grid.x <= posB.x  || posB.x < 0 || m_grid.y <= posB.y || posB.y < 0)
        {
            // 外側
            return MoveInfo.OUTSIDE;
        }

        // 移動するブロックを保持
        var block = CheckBlock(posA);
        // posAにブロックがない
        if (block == null)
        {
            // ブロックが存在しない
            return MoveInfo.NOTHING;
        }

        // 移動先が埋まっている
        if (CheckBlock(posB))
        {
            // パワー不足で押せない
            if (power <= 0)
            {
                // パワー不足
                return MoveInfo.MSSINGHINGPOWER;
            }

            // 移動先ブロック
            var fblock = CheckBlock(posB);
            // 移動方向
            var dir = posB - posA;
            // ただしY軸は反転する
            dir.y *= -1;
            // もし移動先のブロックがさらに奥に移動出来たら
            if (fblock.Move(dir, power - 1))
            {
                // TODO:押し込み音を流す
            }
            else
            {
                // 使用中
                return MoveInfo.USED;
            }
        }    

        // posAからposBへコピー
        RegisterBlock(CheckBlock(posA), posB);
        // 元居た場所を片付ける
        UnregisterBlock(posA);
        // 移動に成功
        return MoveInfo.SUCCESS; 
    }

    // ブロックを登録する
    public void RegisterBlock(BlockParameter block, Vector2Int pos)
    {
        RegisterBlock(block, pos.x, pos.y);
    }
    public void RegisterBlock(BlockParameter block, int horizon, int vertical)
    {
        Blocks[vertical][horizon] = block;
    }

    // ブロックを登録解除する(削除するわけではない)
    public void UnregisterBlock(Vector2Int pos)
    {
        UnregisterBlock(pos.x, pos.y);
    }
    public void UnregisterBlock(int horizon, int vertical)
    {
        // 破壊できれば破壊する
        if(Blocks[vertical][horizon] == null || Blocks[vertical][horizon].CanDestroy)
            Blocks[vertical][horizon] = null;
    }
}
