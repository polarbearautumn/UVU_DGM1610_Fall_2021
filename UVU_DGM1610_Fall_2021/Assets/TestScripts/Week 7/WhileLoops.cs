using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileLoops : MonoBehaviour
{
   static void Main(string[] args)
   {
      int x = 20;
      while (x > 10)
      {
         Console.WriteLine(x);
         x--;
      }
   }
}
