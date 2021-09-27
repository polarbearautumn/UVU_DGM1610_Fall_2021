using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    static void Main(string[] args)
    {
        int pokemon = 001;
        switch (pokemon)
        {
            case 001:
                Console.WriteLine("Bulbasaur");
                break;
            case 004:
                Console.WriteLine("Charmander");
                break;
            case 007:
                Console.WriteLine("Squirtle");
                break;
            default:
                Console.WriteLine("Gotta catch 'em all");
                break;
        }
    }
}
