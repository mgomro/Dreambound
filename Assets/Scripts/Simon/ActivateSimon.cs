using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SoundFXMananger;

public class ActivateSimon : GameActivable
{
    public SimonController simonController;
    public TextMeshProUGUI countText;

    void Start()
    {
        countText.gameObject.SetActive(false);
    }

    public override void Activate()
    {
        if (!simonController.IsStarting())
        {
            simonController.SetStarting();
            InitCount();
            SoundManager.Instance.LowerVolume(0.25f, 3f);
        }
            
    }

    public void InitCount()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(0.4f);
        
        for (int i = 3; i > 0; i--)
        {
            countText.text = i.ToString();
            SoundFXMananger.Instance.PlaySound(SoundType.CountDown);
            countText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            countText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);

        }

        countText.gameObject.SetActive(false);
        simonController.StartGame();
    }

}
