using DialogueEditor;
using System.Collections;
using UnityEngine;

public class InteractRobot : Interactable
{
    public NPCConversation[] conversations;
    public Sprite[] spritesRobot;
    public BoxCollider2D panelCode;
    public bool isActive = false;

    private SpriteRenderer spriteRenderer;
    private Sprite currentSprite;
    private bool alreadyActivated = false;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        if (isActive)
        {
            if (!alreadyActivated)
            {
                ConversationManager.Instance.StartConversation(gameObject.GetComponent<NPCConversation>()); // The robot starts the conversation.
                StartCoroutine(WaitForConversationEnd());
                
                StartCoroutine(ChangeSprite());

                panelCode.enabled = true;
                alreadyActivated = true;
            }
            else
            {
                ConversationManager.Instance.StartConversation(conversations[2]); // The player calls the robot's attention after finishing the conversation.
            }
        }
        else
        {
            ConversationManager.Instance.StartConversation(conversations[0]); // Robot no active
        }
    }

    private IEnumerator WaitForConversationEnd()
    {
        yield return new WaitUntil(() => !ConversationManager.Instance.IsConversationActive);
        spriteRenderer.sprite = currentSprite;
        ConversationManager.Instance.StartConversation(conversations[1]); // Automatic dialogue after the robot ends the conversation.
    }

    private IEnumerator ChangeSprite()
    {
        float timeBetweenSprites = 1.5f;
        currentSprite = spriteRenderer.sprite;

        foreach (Sprite sprite in spritesRobot)
        {
            yield return new WaitForSeconds(timeBetweenSprites);
            spriteRenderer.sprite = sprite;
            timeBetweenSprites += 1f;


        }
    }
}

