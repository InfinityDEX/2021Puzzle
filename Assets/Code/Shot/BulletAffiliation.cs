using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAffiliation : MonoBehaviour
{
    [SerializeField] BlockParameter.Team m_team;
    // どの勢力の攻撃か？
    public BlockParameter.Team GetTeam()
    {
        return m_team;
    }
}
