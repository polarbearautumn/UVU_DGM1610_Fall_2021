using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeachLoopsWithArrays : MonoBehaviour
{
  static void Main(string[] args)
  {
    string[] enemies = {"Goomba", "Koopa", "Boo"};
    foreach (string i in enemies)
    {
      Console.WriteLine(i);
    }
  }
}
