using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 破壊されたとき
    private void OnDestroy()
    {
        // リザルトへ進む
        ServiceLocator.Locator.GetSystem().GameOver();
    }
}
