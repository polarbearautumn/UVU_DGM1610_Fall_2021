using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoopsWithArrays : MonoBehaviour
{
   static void Main(string[] args)
   {
      string[] enemies = {"Goomba", "Koopa", "Boo"};
      for (int i = 0; i < enemies.Length; i++) 
      {
         Console.WriteLine(enemies[i]);
      }
   }
}
