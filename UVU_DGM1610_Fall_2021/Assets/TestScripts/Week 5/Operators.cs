using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operators : MonoBehaviour
{
    private int x = 15;

    void Start()
    {
        x += 5;
    }

    static void Main(string[] args)
    {
        int sum1 = 25 + 50;
        int sum2 = sum1 - 25;
        int sum3 = sum1 + sum1;
        Console.WriteLine(sum1);
        Console.WriteLine(sum2);
        Console.WriteLine(sum3);
    }
}

