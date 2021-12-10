using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;
   
    public void ReplaceValue(Vector3 number)
    {
        value = number;
    }
   
    public void AddValue(Vector3 number)
    {
        value += number;
    }

    public void SubtractValue(Vector3 number)
    {
        value -= number;
    }

}
