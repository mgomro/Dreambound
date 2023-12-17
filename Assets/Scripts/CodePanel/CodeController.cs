using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SoundFXMananger;

public class CodeController : MonoBehaviour
{
    public TextMeshProUGUI screenText;
    public Sprite correctPanel;
    public Sprite wrongPanel;

    private string[] numbers = new string[3];
    private int index = 0;
    private GameObject _codePanel;
    private GameObject _door;
    private string _solution;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ActivatePanel(string solution, GameObject codePanel, GameObject door)
    {
        
        UpdateInitText();

        _codePanel = codePanel;
        _solution = solution;
        _door = door;

        gameObject.GetComponent<Image>().sprite = wrongPanel;
        gameObject.SetActive(true);

        InitPlayer.playerObject.GetComponent<InteractController>().InteractingOn();
    }

    public void ClosePanel()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ButtonPanel);
        DisablePanel();
    }

    private void DisablePanel()
    {
        UpdateInitText();
        ClearArray();
        gameObject.SetActive(false);
        GameManager.instance.SetDefaultCursor();
        InitPlayer.playerObject.GetComponent<InteractController>().InteractingOff();
    }

    public void AddNumber(TextMeshProUGUI numberButton)
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ButtonPanel);
        if (index < 3)
        {
            int number;
            if (int.TryParse(numberButton.text, out number))
            {
                numbers[index] = number.ToString();
                index++;
                UpdateText();
            }
        }
    }

    void UpdateInitText()
    {
        StringBuilder builder = new StringBuilder("*  *  *  *  *");
        screenText.text = builder.ToString();
    }

    void UpdateText()
    {
        StringBuilder builder = new StringBuilder("*");

        for (int i = 0; i < 3; i++)
        {
            builder.Append("  ").Append(!string.IsNullOrEmpty(numbers[i]) ? numbers[i] : "*");
        }

        builder.Append("  *");

        screenText.text = builder.ToString();

        if (index == 3)
        {
            Invoke("isEquals", 0.5f);
        }
        
    }

    void isEquals()
    {
        if  (string.Equals(_solution, screenText.text, StringComparison.Ordinal))
        {
            gameObject.GetComponent<Image>().sprite = correctPanel;

            SoundFXMananger.Instance.PlaySound(SoundType.CorrectCode);
            _codePanel.GetComponent<InteractPanel>().ChangeSprite();
            StartCoroutine(CorrectCode());
                
        }
        else
        {
            UpdateInitText();
            ClearArray();
            SoundFXMananger.Instance.PlaySound(SoundType.Incorrect);
        }
    }

    private IEnumerator  CorrectCode()
    {
        yield return new WaitForSeconds(0.8f);
        SoundFXMananger.Instance.PlaySound(SoundType.OpenDoor);
        _door.SetActive(false);
        DisablePanel();
    }

    void ClearArray()
    {
        Array.Clear(numbers, 0, numbers.Length);
        index = 0;
    }

}
