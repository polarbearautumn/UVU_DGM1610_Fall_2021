using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour

{
    string myName = "Autumn Jones";
    char myInitial = 'A';

    int myAge = 20;

    float myExactAge = 19.9F;

    float myHeight = 5.3F;

    double myExactHeight = 5.3999999D;

    long myStudentLoanDebt;

    bool myBool = true;

    void Start()
    {
        Debug.Log(myName);
        Debug.Log(myInitial);
        Debug.Log(myAge);
        Debug.Log(myExactAge);
        Debug.Log(myHeight);
        Debug.Log(myExactHeight);
        Debug.Log(myStudentLoanDebt);
        Debug.Log(myBool);
        myHeight = 6.3F;
        myStudentLoanDebt = 100000000L;
    }
}




