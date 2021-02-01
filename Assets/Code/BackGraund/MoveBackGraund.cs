using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGraund : MonoBehaviour
{
    [SerializeField] float m_startPointY;
    [SerializeField] float m_returnPointY;
    [SerializeField] float m_speed;

    void FixedUpdate()
    {
        // 指定した座標以下まで下がったら
        if(transform.position.y <= m_returnPointY)
        {
            // スタート地点に戻す
            transform.position  = new Vector3(transform.position.x, m_startPointY, transform.position.z);
        }
        // 0.1メートルの速度で下に移動
        transform.Translate(Vector3.down * m_speed);
    }
}
