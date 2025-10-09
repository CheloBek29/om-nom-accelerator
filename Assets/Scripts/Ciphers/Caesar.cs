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

    private char[] _alphabet = "אבגדהו¸זחטיךכלםמןנסעףפץצקרשתûü‎‏ÿ".ToCharArray();
    private Dictionary<char, int> _alphabetDict = new()
    {
        { 'א', 0 },
        { 'ב', 1 },
        { 'ג', 2 },
        { 'ד', 3 },
        { 'ה', 4 },
        { 'ו', 5 },
        { '¸', 6 },
        { 'ז', 7 },
        { 'ח', 8 },
        { 'ט', 9 },
        { 'י', 10 },
        { 'ך', 11 },
        { 'כ', 12 },
        { 'ל', 13 },
        { 'ם', 14 },
        { 'מ', 15 },
        { 'ן', 16 },
        { 'נ', 17 },
        { 'ס', 18 },
        { 'ע', 19 },
        { 'ף', 20 },
        { 'פ', 21 },
        { 'ץ', 22 },
        { 'צ', 23 },
        { 'ק', 24 },
        { 'ר', 25 },
        { 'ש', 26 },
        { 'ת', 27 },
        { 'û', 28 },
        { 'ü', 29 },
        { '‎', 30 },
        { '‏', 31 },
        { 'ÿ', 32 }
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
