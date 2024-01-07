using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingLevel1 : MonoBehaviour
{
    public Vector3 newCamPos;

    private static GameObject player;
    private CamController camControl;    
    private PlayerController playerController;
    private Animator playerAnimator;
    private Transform playerTransform;


    void Start()
    {
        player = InitPlayer.playerObject;
        camControl = Camera.main.GetComponent<CamController>();

        playerController = player.GetComponent<PlayerController>();
        playerAnimator = player.GetComponent<Animator>();
        playerTransform = player.transform;
        
    }
        
    public void SetPlayerPostion()
    {
        SetPositionCamera();
        playerTransform.localScale = new Vector3(1f, 1f, 1f);
        playerTransform.position = gameObject.transform.position;
        playerAnimator.SetFloat("LastHorizontal", 0);
    }

    private void SetPositionCamera()
    {
        camControl.minPos += newCamPos;
        camControl.maxPos += newCamPos;
    }

    public void SoundMusicIntro()
    {
        SoundManager.Instance.ChangeMusicGradually(SoundManager.Instance.SoundIntro, 2f);
    }
    public void DesactiveController()
    {
        playerController.enabled = false;
    }

    public void SetIdleLeft()
    {
        playerAnimator.SetFloat("LastHorizontal", -1);        
    }

    public void ActiveCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DesactiveCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
