using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatData : ScriptableObject
{
    public float value;
   
    public void ReplaceValue(float number)
    {
        value = number;
    }
   
    public void AddValue(float number)
    {
        value += number;
    }

    public void MultiplyValue(float number)
    {
        value *= number;
    }
    
    public void DivideValue(float number)
    {
        value /= number;
    }

    public void SubtractValue(float number)
    {
        value -= number;
    }
    
}
