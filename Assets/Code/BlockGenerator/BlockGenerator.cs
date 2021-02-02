using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    // フィールドマネージャー
    [SerializeField] FieldManager m_fieldManager; 
    // 生成地点
    private Vector2Int m_generatePoint;

    public void CreateBlock(BlockParameter block)
    {
        if(!m_fieldManager.CheckBlock(m_generatePoint))
        {
            // オブジェクト作成
            BlockParameter go = new BlockParameter();
            go = Instantiate(block, transform);
            go.transform.parent = m_fieldManager.gameObject.transform;
            go.transform.localPosition = new Vector3(m_generatePoint.x, -m_generatePoint.y);
            go.FieldManager = m_fieldManager;
            go.SetPosition(m_generatePoint.x, m_generatePoint.y);

            m_fieldManager.RegisterBlock(go, m_generatePoint.x, m_generatePoint.y);
        }
    }

    public void RegisterPoint(Vector2Int point)
    {
        m_generatePoint = point;
    }
}
