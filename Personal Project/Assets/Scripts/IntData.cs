using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

   public void ChangeImageFillAmount(Image img)
   {
      img.fillAmount = value;
   }

   public void DisplayNumber(TextMeshProUGUI text)
   {
      text.text = value.ToString();
   }
}
