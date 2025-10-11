using UnityEngine;
using TMPro;
using System.Collections;

public class VisualNovelDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typingSpeed = 0.02f; // секунд на символ

    // Текст диалога — каждая строка отдельно
    private string[] lines = new string[]
    {
        "Переехал в дом на окраине.",
        "Не потому что хотел — просто больше некуда.",
        "",
        "Тётя Вера оставила его мне.",
        "Мы никогда не общались.",
        "",
        "В подвале, за ящиком с гвоздями, нашёл дневник.",
        "1970-х годов. Автор — Элиана Воронцова.",
        "Незнакомка.",
        "",
        "Но когда прочитал первые строки…",
        "Вспомнил запах пыли. Скрип этого пола.",
        "И как меня, пятилетнего, вели за руку по этим комнатам.",
        "",
        "Я не помню зачем.",
        "Не помню кем она была.",
        "",
        "Но дневник написан шифрами.",
        "И, кажется, он ждал именно меня.",
        "",
        "Попробую разобраться."
    };

    private int currentLineIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        dialogueText.text = "";
        StartCoroutine(ShowNextLine());
    }

    IEnumerator ShowNextLine()
    {
        if (currentLineIndex >= lines.Length)
        {
            Debug.Log("Диалог завершён.");
            yield break;
        }

        string line = lines[currentLineIndex];
        currentLineIndex++;

        isTyping = true;
        dialogueText.text = "";

        // Печатаем текст посимвольно
        for (int i = 0; i < line.Length; i++)
        {
            dialogueText.text += line[i];
            yield return new WaitForSeconds(typingSpeed);

            // Если нажали ЛКМ или Пробел — пропускаем анимацию
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                break;
            }
        }

        // Убеждаемся, что весь текст отображён
        dialogueText.text = line;
        isTyping = false;

        // Ждём нажатия ЛКМ или Пробела для перехода к следующей строке
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space));

        // Рекурсивно показываем следующую строку
        StartCoroutine(ShowNextLine());
    }
}