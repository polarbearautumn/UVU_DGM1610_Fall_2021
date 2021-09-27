using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Conditionals : MonoBehaviour
{
    static void Main(string[] args)
    {
        int hunger = 55;
        if (hunger <= 25)
        {
            Console.WriteLine("I'm stuffed!");
        }
        else if (hunger <= 50)
        {
            Console.WriteLine("I'm hungry.");
        }
        else
        {
            Console.WriteLine("I'm starving!");
        }
    }
}
