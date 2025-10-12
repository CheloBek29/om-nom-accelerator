using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Vigenere : MonoBehaviour
{
    [SerializeField] TMP_Text m_cypherKey;
    [SerializeField] TMP_Text m_cypherText;
    [SerializeField] TMP_Text m_resText;

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

    private string getResKey(string key, int n)
    {
        string res = "";
        for (int i = 0; i < n; i++)
        {
            res += key[i % (key.Length - 1)];
        }

        return res;
    }

    public void Decrypt()
    {
        string encryptedText = m_cypherText.text.ToLower();
        string encTextWithoutSpaces = encryptedText.Replace(" ", "");
        string key = getResKey(m_cypherKey.text, encTextWithoutSpaces.Length).ToLower();
        string res = "";
        int delta = 0;
        int id = 0;
        for (int i = 0; i - delta < key.Length; i++)
        {
            id = i - delta;
            if (encryptedText[i] == ' ')
            { 
                res += " ";
                delta++;
                continue; 
            }

            int keyLetId = _alphabetDict[key[id]];
            int encLetId = _alphabetDict[encTextWithoutSpaces[id]];
            int decLetId = (encLetId - keyLetId + 33) % 33;
            char resLet = _alphabet[decLetId];
            res += resLet;
        }

        m_resText.text = res;
    }
}
