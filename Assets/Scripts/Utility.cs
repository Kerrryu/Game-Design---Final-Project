using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    private static string[] nameSection1 = new string[] {"Ge","Me","Ta","Bo","Ke","Ra","Ne","Mi" };
    private static string[] nameSection2 = new string[] {"oo","ue","as","to","ra","me","io","so" };
    private static string[] nameSection3 = new string[] {"se","matt","lace","fo","cake","end" };

    public static string GenerateName() {
        return nameSection1[Random.Range(0, nameSection1.Length)] + nameSection2[Random.Range(0, nameSection2.Length)] + nameSection3[Random.Range(0, nameSection3.Length)]; 
    } 
}
