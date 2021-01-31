using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ファジー関数
class Fuzzy { 
    // 傾斜型のメンバシップ関数
    public static float FuzzyGrade(float value, float x0, float x1)
    {
        float x = value;

        if (x <= x0)
        {
            return 0;
        }
        else if (x >= x1)
        {
            return 1;
        }
        else
        {
            // 分母を計算
            float denom = x1 - x0;
            return (x / denom) - (x0 / denom);
        }
    }
    // 逆傾斜型のメンバシップ関数
    public static float FuzzyReverseGrade(float value, float x0, float x1)
    {
        float x = value;

        if (x <= 0)
        {
            return 1;
        }
        else if (x >= x1)
        {
            return 0;
        }
        else
        {
            float denom = x1 - x0;
            return (x1 / denom) - (x / denom);
        }
    }
    // 三角形型のメンバシップ関数
    public static float FuzzyTriangle(float value, float x0, float x1, float x2)
{
    float x = value;

    if (x <= x0)
    {
        return 0;
    }
    else if (x == x1)
    {
        return 1;
    }
    else if ((x > x0) && (x < x1))
    {
        float denom = x1 - x0;
        return (x / denom) - (x0 / denom);
    }
    else
    {
        float denom = x2 - x1;
        return (x2 / denom) - (x / denom);
    }
}
    // 台形型のメンバシップ関数
    public static float FuzzyTrapezoid(float value, float x0, float x1, float x2, float x3)
{
    float x = value;

    if (x <= x0)
    {
        return 0;
    }
    else if ((x >= x1) && (x <= x2))
    {
        return 1;
    }
    else if ((x > x0) && (x < x1))
    {
        float denom = x1 - x0;
        return (x / denom) - (x0 / denom);
    }
    else
    {
        float denom = x3 - x2;
        return (x3 / denom) - (x / denom);
    }
}
    // 逆台形型のメンバシップ関数
    public static float FuzzyReverseTrapezoid(float value, float x0, float x1, float x2, float x3)
{
    float x = value;

    if (x <= x0)
    {
        return 1;
    }
    else if ((x >= x1) && (x <= x2))
    {
        return 0;
    }
    else if ((x > x0) && (x < x1))
    {
        float denom = x1 - x0;
        return 1 - ((x / denom) - (x0 / denom));
    }
    else
    {
        float denom = x3 - x2;
        return 1 - ((x3 / denom) - (x / denom));
    }
}
}