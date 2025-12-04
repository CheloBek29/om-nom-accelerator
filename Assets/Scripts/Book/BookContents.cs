using System.Collections;
using TMPro;
using UnityEngine;

namespace ChristinaCreatesGames.Typography.Book
{
    public class BookContents : MonoBehaviour
    {
        [Header("Основной контейнер книги")]
        [Tooltip("Перетащите сюда родительский объект всего UI книги, который будет скрываться/показываться")]
        [SerializeField] private GameObject bookContainer;

        [Header("Файл с текстом")]
        [SerializeField] private TextAsset bookContentFile;

        [Header("Отображаемые страницы")]
        [SerializeField] private TMP_Text leftSide;
        [SerializeField] private TMP_Text rightSide; 
        
        [Header("Пагинация")]
        [SerializeField] private TMP_Text leftPagination;
        [SerializeField] private TMP_Text rightPagination;

        [Header("Источник данных (невидимый)")]
        [SerializeField] private TMP_Text textSourceMaster;

        private int currentPageNumber = 1;
        private int totalPageCount = 0;

        // Флаг, который не даст книге инициализироваться повторно
        private bool isInitialized = false;

        private void OnEnable()
        {
            Debug.Log(isInitialized);
            if (!isInitialized)
            {
                StartCoroutine(InitializeBook());
                isInitialized = true;
            }
            
        }

        private IEnumerator InitializeBook()
        {
            yield return new WaitForEndOfFrame();
            Debug.Log("Initialize Book");
            SetupContent(bookContentFile.text);
        }

        private void SetupContent(string content)
        {
            textSourceMaster.color = new Color(0, 0, 0, 0); // Делаем Мастера невидимым
            textSourceMaster.text = content;

            // Считаем страницы ТОЛЬКО через Мастера
            textSourceMaster.ForceMeshUpdate(true); 
            
            if (textSourceMaster.textInfo == null)
            {
                Debug.LogError("Не удалось сгенерировать textInfo у TextSource_Master.", this);
                return;
            }

            totalPageCount = textSourceMaster.textInfo.pageCount;
            Debug.Log($"Книга настроена. Общее количество страниц: {totalPageCount}");

            if (totalPageCount == 0) return;
            
            currentPageNumber = 1;
            UpdateBookView();
        }

        private void UpdateBookView()
        {
            // Номера страниц в массиве начинаются с 0
            int leftPageIndex = currentPageNumber - 1;
            
            // --- НОВАЯ ЛОГИКА ДЛЯ ЛЕВОЙ СТРАНИЦЫ ---
            if (leftPageIndex >= 0 && leftPageIndex < totalPageCount)
            {
                TMP_PageInfo pageInfo = textSourceMaster.textInfo.pageInfo[leftPageIndex];
                int startIndex = pageInfo.firstCharacterIndex;
                int length = pageInfo.lastCharacterIndex - startIndex + 1;

                // "Вырезаем" текст для этой страницы и присваиваем его
                leftSide.text = textSourceMaster.text.Substring(startIndex, length);
            }
            else
            {
                leftSide.text = ""; // На всякий случай
            }

            leftPagination.text = currentPageNumber.ToString();

            // --- НОВАЯ ЛОГИКА ДЛЯ ПРАВОЙ СТРАНИЦЫ ---
            int rightPageNumber = currentPageNumber + 1;
            int rightPageIndex = rightPageNumber - 1;

            if (rightPageIndex < totalPageCount)
            {
                rightSide.gameObject.SetActive(true);
                
                TMP_PageInfo pageInfo = textSourceMaster.textInfo.pageInfo[rightPageIndex];
                int startIndex = pageInfo.firstCharacterIndex;
                int length = pageInfo.lastCharacterIndex - startIndex + 1;
                
                rightSide.text = textSourceMaster.text.Substring(startIndex, length);
                rightPagination.text = rightPageNumber.ToString();
            }
            else
            {
                rightSide.gameObject.SetActive(false);
                rightSide.text = "";
                rightPagination.text = "";
            }
        }

        public void NextPage()
        {
            if (currentPageNumber < totalPageCount - 1)
            {
                currentPageNumber += 2;
                UpdateBookView();
            }
        }

        public void PreviousPage()
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 2;
                UpdateBookView();
            }
        }
    }
}