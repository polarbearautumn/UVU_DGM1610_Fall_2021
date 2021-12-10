using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class IntData : ScriptableObject

{
   public int value;
   
   public void ReplaceValue(int number)
   {
      value = number;
   }
   
   public void AddValue(int number)
   {
      value += number;
   }

   public void DivideValue(int number)
   {
      value /= number;
   }

   public void SubtractValue(int number)
   {
      value -= number;
   }

   public void ChangeImageFillAmount(Image sprite)
   {
      sprite.fillAmount = value;
   }

   public void DisplayNumber(TextMeshProUGUI health)
   {
      health.text = value.ToString();
   }
}
