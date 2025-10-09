using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Caesar : MonoBehaviour
{
    [SerializeField] TMP_Text shiftNum;
    [SerializeField] TMP_Text cypherText;
    [SerializeField] TMP_Text resText;

    private char[] _alphabet = "��������������������������������".ToCharArray();
    private Dictionary<char, int> _alphabetDict = new()
    {
        { '�', 0 },
        { '�', 1 },
        { '�', 2 },
        { '�', 3 },
        { '�', 4 },
        { '�', 5 },
        { '�', 6 },
        { '�', 7 },
        { '�', 8 },
        { '�', 9 },
        { '�', 10 },
        { '�', 11 },
        { '�', 12 },
        { '�', 13 },
        { '�', 14 },
        { '�', 15 },
        { '�', 16 },
        { '�', 17 },
        { '�', 18 },
        { '�', 19 },
        { '�', 20 },
        { '�', 21 },
        { '�', 22 },
        { '�', 23 },
        { '�', 24 },
        { '�', 25 },
        { '�', 26 },
        { '�', 27 },
        { '�', 28 },
        { '�', 29 },
        { '�', 30 },
        { '�', 31 },
        { '�', 32 }
    };

    private string shift(string cypherText, int shift=1)
    {
        string cypherRes = "";
        foreach (char c in cypherText)
        {
            int resIndex = (_alphabetDict[c] + shift) % 33;
            char resLetter = _alphabetDict.FirstOrDefault(x => x.Value == resIndex).Key;
            cypherRes += resLetter;
        }
        return cypherRes;
    }

    public void Decrypt()
    {
        resText.text = this.shift(cypherText.text.ToLower(), -Int32.Parse(shiftNum.text));

    }
}
