using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// フィールドの生成から管理まで
public class GridGenerator : MonoBehaviour
{
    [SerializeField] FieldManager fieldManager;
    [SerializeField] GameObject m_gridImage;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < fieldManager.m_grid.x; i++)
        {
            for (int j = 0; j < fieldManager.m_grid.y; j++)
            {
                GameObject grid = Instantiate(m_gridImage, this.transform);
                grid.transform.position += new Vector3(i,-j);
            }
        }
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
