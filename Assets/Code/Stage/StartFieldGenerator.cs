using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFieldGenerator : MonoBehaviour
{
    // ステージデータのファイル
    [SerializeField] TextAsset m_file;
    // プレイヤーのプレハブ
    [SerializeField] BlockParameter m_player;
    // ショット砲のプレハブ
    [SerializeField] BlockParameter m_shot;
    // レーザー砲のプレハブ
    [SerializeField] BlockParameter m_laser;
    // シールドのプレハブ
    [SerializeField] BlockParameter m_shield;
    // フィールドの初期データ
    private List<List<int>> m_field;
    void Awake()
    {
        // テキストを受け取る
        string text = m_file.text;

        m_field = new List<List<int>>();

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        StringReader reader = new StringReader(text);
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            string[] csvDatas = line.Split(','); // , 区切りでリストに追加
            // 横のラインを定義
            List<int> horizon = new List<int>();
            // 文字の配列を整数配列に変換
            for (int i = 0; i < csvDatas.Length; i++)
            {
                // 整数化したデータをセット
                horizon.Add(int.Parse(csvDatas[i]));
            }
            // 横列を追加
            m_field.Add(horizon);
        }

        var firldManager = GetComponent<FieldManager>();

        firldManager.m_grid.x = m_field[0].Count;
        firldManager.m_grid.y = m_field.Count;
        transform.position += new Vector3(0, m_field.Count - 1);
    }

    private void Start()
    {
        var firldManager = GetComponent<FieldManager>();
        for (int i = 0; i < m_field.Count; i++)
        {
            List<BlockParameter> blockLine = new List<BlockParameter>();
            for (int j = 0; j < m_field[i].Count; j++)
            {
                BlockParameter block = new BlockParameter();
                switch (m_field[i][j])
                {
                    case 1:
                        // ショット砲作成
                        block = Instantiate(m_shot, transform);
                        block.transform.localPosition = new Vector3(j, -i);
                        block.FieldManager = firldManager;
                        block.SetPosition(j, i);
                        blockLine.Add(block);
                        break;
                    case 2:
                        // レーザー砲作成
                        block = Instantiate(m_laser, transform);
                        block.transform.localPosition = new Vector3(j, -i);
                        block.FieldManager = firldManager;
                        block.SetPosition(j, i);
                        blockLine.Add(block);
                        break;
                    case 3:
                        // シールド作成
                        block = Instantiate(m_shield, transform);
                        block.transform.localPosition = new Vector3(j, -i);
                        block.FieldManager = firldManager;
                        block.SetPosition(j, i);
                        blockLine.Add(block);
                        break;
                    case 4:
                        // プレイヤー作成
                        block = Instantiate(m_player, transform);
                        block.transform.localPosition = new Vector3(j, -i);
                        block.FieldManager = firldManager;
                        block.SetPosition(j, i);
                        blockLine.Add(block);
                        break;
                    default:
                        blockLine.Add(null);
                        break;
                }
            }
            firldManager.Blocks.Add(blockLine);
        }
    }
}
