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

    private char[] _alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
    private Dictionary<char, int> _alphabetDict = new()
    {
        {'а', 0},
        {'б', 1},
        {'в', 2},
        {'г', 3},
        {'д', 4},
        {'е', 5},
        {'ё', 6},
        {'ж', 7},
        {'з', 8},
        {'и', 9},
        {'й', 10},
        {'к', 11},
        {'л', 12},
        {'м', 13},
        {'н', 14},
        {'о', 15},
        {'п', 16},
        {'р', 17},
        {'с', 18},
        {'т', 19},
        {'у', 20},
        {'ф', 21},
        {'х', 22},
        {'ц', 23},
        {'ч', 24},
        {'ш', 25},
        {'щ', 26},
        {'ъ', 27},
        {'ы', 28},
        {'ь', 29},
        {'э', 30},
        {'ю', 31},
        {'я', 32}
    };

    private string shift(string cypherText, int shift=1)
    {
        string cypherRes = "";
        foreach (char c in cypherText)
        {
            if (_alphabet.Contains(c))
            {
                int resIndex = (_alphabetDict[c] - shift + 33) % 33;
                char resLetter = _alphabetDict.FirstOrDefault(x => x.Value == resIndex).Key;
                cypherRes += resLetter;
            }
            else cypherRes += " ";
        }
        return cypherRes;
    }

    public void Decrypt()
    {
        resText.text = this.shift(cypherText.text.ToLower(), Int32.Parse(shiftNum.text));

    }
}
