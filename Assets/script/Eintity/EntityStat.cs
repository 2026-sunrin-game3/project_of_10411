using UnityEngine;
using System.Collections.Generic;


public enum MathType
{
    Increase,
    Decrease,
    Add,
    Remove
}

public class EntityStat : MonoBehaviour
{
    Dictionary<string, float> baseValue = new();
    Dictionary<string, float> resultValue = new();
    public List<Buf> bufs = new();

    public struct Buf
    {
        public string Key;
        public MathType mathtype;
        public float Value;
    }

    [System.Serializable]

    struct StatValue
    {
        public string Key;
        public float Value;
    }
    [SerializeField]

    List<StatValue> defualtStat = new()
    {
        new StatValue{Key="attackDamage",Value=3},
        new StatValue{Key="defense",Value=0},
        new StatValue{Key="increaseDamage",Value=0},
        new StatValue{Key="critPer",Value=0},
        new StatValue{Key="critMul",Value=0},
        new StatValue{Key="hurtDamage",Value=0},
        new StatValue{Key="atkSpeed",Value=0},
        new StatValue{Key="moveSpeed",Value=0},

    };


    void Start()
    {
        foreach (StatValue val in defualtStat)
        {
            baseValue[val.Key] = val.Value;
            calc(val.Key);
        }
    }
    public float GetResultValue(string Key)
    {
        return resultValue[Key];
    }

    public float calc(string Key)
    {
        float value = baseValue[Key];
        float increase = 100;

        foreach (Buf buf in bufs)
        {
            switch (buf.mathtype)
            {
                case MathType.Increase:
                    increase += buf.Value;
                    break;
                case MathType.Decrease:
                    increase -= buf.Value;
                    break;
                case MathType.Add:
                    value += buf.Value;
                    break;
                case MathType.Remove:
                    value -= buf.Value;
                    break;
            }
        }
        return resultValue[Key] = value * increase * 0.01f;
    }








}
