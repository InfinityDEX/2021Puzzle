using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpirGenerator : MonoBehaviour
{
    // 隊列データのファイル
    [SerializeField] TextAsset m_file;
    // 大砲戦艦
    [SerializeField] GameObject m_cannon;
    // レーザー戦艦
    [SerializeField] GameObject m_laser;
    // シールド戦艦
    [SerializeField] GameObject m_shield;
    // 隊列リスト
    private List<List<GameObject>> m_unitList;

    void Awake()
    {
        // テキストを受け取る
        string text = m_file.text;

        m_unitList = new List<List<GameObject>>();

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        StringReader reader = new StringReader(text);
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            string[] csvDatas = line.Split(','); // , 区切りでリストに追加
            // 横のラインを定義
            List<GameObject> horizon = new List<GameObject>();
            // 文字の配列を整数配列に変換
            for (int i = 0; i < csvDatas.Length; i++)
            {
                switch (int.Parse(csvDatas[i]))
                {
                    case 1:
                        // 大砲戦艦のデータをセット
                        horizon.Add(m_cannon);
                        break;
                    case 2:
                        // レーザー戦艦のデータをセット
                        horizon.Add(m_laser);
                        break;
                    case 3:
                        // シールド戦艦のデータをセット
                        horizon.Add(m_shield);
                        break;
                    default:
                        // null状態にする
                        horizon.Add(null);
                        break;
                }


            }
            // 横列を追加
            m_unitList.Add(horizon);
        }
    }

    public List<BlockParameter> Generate()
    {
        List<BlockParameter> result = new List<BlockParameter>();
        var unit = m_unitList[Random.Range(0, m_unitList.Count - 1)];

        for (int i = 0; i < unit.Count; i++)
        {
            if (unit[i] == null)
                continue;
            var go = Instantiate(unit[i]);
            go.transform.parent = transform;
            go.transform.localPosition = new Vector3(i, 0);
            go.transform.rotation = Quaternion.Euler(0, 0, 180);
            result.Add(go.GetComponent<BlockParameter>());
        }
        return result;
    }
}
