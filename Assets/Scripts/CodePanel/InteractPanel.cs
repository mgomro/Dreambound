using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundFXMananger;

public class InteractPanel : Interactable
{
    public GameObject panel;
    public GameObject door;
    public Sprite correctPanel;
    public string solution;

    public override void Interact()
    {
        SoundFXMananger.Instance.PlaySound(SoundType.ActiveCodePanel);
        panel.GetComponent<CodeController>().ActivatePanel(solution, gameObject, door);
    }

    public void ChangeSprite()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = correctPanel;    
    }
    
}
