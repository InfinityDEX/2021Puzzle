using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public BlockParameter m_blockParameter;
    [SerializeField] int m_power;
    private MovementObject m_movement;
    // Start is called before the first frame update
    void Start()
    {
        m_blockParameter = GetComponent<BlockParameter>();
        m_movement = GetComponent<MovementObject>();
    }

    // Update is called once per frame
    void Update()
    {
        bool result = false;
        // 上に移動
        if(Input.GetKey(KeyCode.UpArrow))
        {
            result = m_blockParameter.Move(Vector2Int.up, m_power);
        }
        // 下に移動
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            result = m_blockParameter.Move(Vector2Int.down, m_power);
        }
        // 右に移動
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            result = m_blockParameter.Move(Vector2Int.right, m_power);
        }
        // 左に移動
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            result = m_blockParameter.Move(Vector2Int.left, m_power);
        }

        // 移動出来ていたら
        if(result)
        {
            // 画像を回転させる
            transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(m_movement.Dir.x, m_movement.Dir.y));
            // TODO:移動音を流す
        }
    }
}
