using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurveManager
{
    private static readonly Dictionary<CurveType, Ease> curveDictionary = new Dictionary<CurveType, Ease>
    {
        { CurveType.Sine, new EaseSine() },
        { CurveType.Cubic, new EaseCubic() },
        { CurveType.Quint, new EaseQuint() },
        { CurveType.Circ, new EaseCirc() },
        { CurveType.Quad, new EaseQuad() },
        { CurveType.Expo, new EaseExpo() }

    };


    public static float ApplyCurve(CurveType type, EaseType easeType, float t)
    {
        var curve = curveDictionary[type];

        switch (easeType)
        {
            case EaseType.EaseIn:
                return curve.EaseIn(t);
            case EaseType.EaseOut:
                return curve.EaseOut(t);
            case EaseType.EaseInOut:
                return curve.EaseInOut(t);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum CurveType
{
    Sine,
    Cubic,
    Quint,
    Circ,
    Quad,
    Expo
}

public enum EaseType
{
    EaseIn,
    EaseOut,
    EaseInOut
}

[Serializable]
public abstract class Ease
{
    public abstract float EaseIn(float _t);
    public abstract float EaseOut(float _t);
    public abstract float EaseInOut(float _t);
}

[Serializable]
public class EaseSine : Ease
{
    public override float EaseIn(float _t)
    {
        
        return 1f - MathF.Cos((_t * MathF.PI) / 2f);
    }
    public override float EaseOut(float _t)
    {
        return MathF.Sin((_t * MathF.PI) / 2f);
    }

    public override float EaseInOut(float _t)
    {
        return 0.5f * (1 - MathF.Cos(_t * MathF.PI));
    }


}

[Serializable]
public class EaseCubic : Ease
{

    public override float EaseIn(float _t)
    {
        return _t * _t * _t;
    }

    public override float EaseOut(float _t)
    {
        return 1f - Mathf.Pow(1f - _t, 3f);
    }

    public override float EaseInOut(float _t)
    {
        return _t < 0.5f ? 4f * _t * _t * _t : 1f - Mathf.Pow(-2f * _t + 2f, 3f) / 2f;
    }
}

[Serializable]
public class EaseQuint : Ease
{
    public override float EaseIn(float _t)
    {
        return _t * _t * _t * _t * _t;
    }

    public override float EaseOut(float _t)
    {
        return 1f - MathF.Pow(1f - _t, 5f);
    }

    public override float EaseInOut(float _t)
    {
        return _t < 0.5f ? 16f * _t * _t * _t * _t * _t : 1 - MathF.Pow(-2f * _t + 2f, 5f) / 2f;
    }

}

[Serializable]
public class EaseCirc : Ease
{
    public override float EaseIn(float _t)
    {
        return Mathf.Clamp01(1f - MathF.Sqrt(MathF.Max(0f, 1f - _t * _t)));
    }


    public override float EaseOut(float _t)
    {
        return MathF.Sqrt(1f - MathF.Pow(_t - 1f, 2f));
    }

    public override float EaseInOut(float _t)
    {
        return _t < 0.5f 
            ? (1 - MathF.Sqrt(1 - MathF.Pow(2f * _t, 2f))) / 2f 
            : (MathF.Sqrt(1 - MathF.Pow(-2f * _t + 2f, 2f)) + 1f) / 2f;

    }

}

[Serializable]
public class EaseQuad : Ease
{
    public override float EaseIn(float _t)
    {
        return _t * _t;
    }

    public override float EaseOut(float _t)
    {
        return 1f - (1f - _t) * (1f - _t);
    }

    public override float EaseInOut(float _t)
    {
        return _t < 0.5f
            ? 2f * _t * _t
            : 1f - MathF.Pow(-2f * _t + 2f, 2f) / 2;
    }
}

[Serializable]
public class EaseExpo : Ease
{
    public override float EaseIn(float _t)
    {
        return _t == 0f
            ? 0f
            : MathF.Pow(2f, 10f * _t - 10f);
    }

    public override float EaseOut(float _t)
    {
        return _t == 1f
            ? 1f
            : 1f - MathF.Pow(2f, -10f * _t);
    }

    public override float EaseInOut(float _t)
    {
        return _t == 0
            ? 0
            : _t == 1f
            ? 1f
            : _t < 0.5f ? MathF.Pow(2f, 20f * _t - 10f) / 2
            : (2f - MathF.Pow(2f, -20f * _t + 10f)) / 2;
    }

}

[Serializable]
public class EaseBack : Ease
{
    public override float EaseIn(float _t)
    {
        const float _c1 = 1.70158f;
        const float _c3 = _c1 + 1f;

        return _c3 * _t * _t * _t - _c1 * _t * _t;
    }

    public override float EaseOut(float _t)
    {
        const float _c1 = 1.70158f;
        const float _c3 = _c1 + 1f;

        return 1f + _c3 * MathF.Pow(_t - 1f, 3f) + _c1 * MathF.Pow(_t - 1f, 2);
    }

    public override float EaseInOut(float _t)
    {
        const float _c1 = 1.70158f;
        const float _c2 = _c1 + 1.525f;

        return _t < 0.5f
            ? (MathF.Pow(2f * _t, 2f) * ((_c2 + 1f) * 2f * _t - _c2)) / 2
            : (MathF.Pow(2f * _t - 2f, 2f) * ((_c2 + 1f) * (_t * 2f - 2f) + _c2) + 2f) / 2;
    }

}

