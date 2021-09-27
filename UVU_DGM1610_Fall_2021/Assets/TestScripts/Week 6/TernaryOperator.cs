using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TernaryOperator : MonoBehaviour
{
    static void Main(string[] args)
    {
        int hunger = 50;
        string result = (hunger <= 25) ? "I'm stuffed." : "I'm starving!";
        Console.WriteLine(result);
    }
}
