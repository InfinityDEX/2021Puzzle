using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorButton : MonoBehaviour
{
    // 生成したいオブジェクト
    [SerializeField] BlockParameter m_generateObject;

    public void OnClick()
    {
        ServiceLocator.Locator.GetBlockGenerator().CreateBlock(m_generateObject);
    }
}
