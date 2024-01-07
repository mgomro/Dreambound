using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundFXMananger;

public class LightOutController : MonoBehaviour
{
    public Sprite lightOnSprite;
    public Sprite lightOffSprite;
    public GameObject[] lights, spritesToDisable;
    public float intervaloDeTiempo = 2f;
    public GameObject door;

    private bool isStarting;

    void Start()
    {
        DisableGame();
        isStarting = false;
    }

    public void StartGame()
    {
        int index = 0;
        foreach (GameObject light in lights)
        {
            SetLightSprite(light, true);
            lights[index].GetComponent<CircleCollider2D>().enabled = true;
            index++;
        }
        isStarting = true;
    }

    public bool IsStarting()
    {
        return isStarting;
    }

    void DisableGame()
    {
        int index = 0;
        foreach (GameObject light in lights)
        {
            SetLightSprite(light, false);
            lights[index].GetComponent<CircleCollider2D>().enabled = false;
            index++;
        }
    }

    public void ToggleLight(int index)
    {
        SetLightSprite(lights[index], !IsLightOn(lights[index]));

        int[] adjacentIndices = GetAdjacentIndices(index);

        foreach (int i in adjacentIndices)
        {
            if (i >= 0 && i < lights.Length)
            {
                SetLightSprite(lights[i], !IsLightOn(lights[i]));
            }
        }

        if (AreAllLightOff())
        {
            StartCoroutine(DisableSprites());           
        }
    }
    public bool AreAllLightOff()
    {
        foreach (GameObject light in lights)
        {
            if (IsLightOn(light))
            {
                return false;
            }
        }
        return true;
    }

    void SetLightSprite(GameObject light, bool isOn)
    {
        SpriteRenderer spriteRenderer = light.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = isOn ? lightOnSprite : lightOffSprite;
    }

    bool IsLightOn(GameObject light)
    {
        SpriteRenderer spriteRenderer = light.GetComponent<SpriteRenderer>();
        return spriteRenderer.sprite == lightOnSprite;
    }

    int[] GetAdjacentIndices(int index)
    {
        int numRows = 3;
        int numCols = 3;

        int row = index / numCols;
        int col = index % numCols;

        List<int> adjacentIndices = new List<int>();

        if (row > 0)
            adjacentIndices.Add(index - numCols);

        if (row < numRows - 1)
            adjacentIndices.Add(index + numCols);

        if (col > 0)
            adjacentIndices.Add(index - 1);

        if (col < numCols - 1)
            adjacentIndices.Add(index + 1);

        return adjacentIndices.ToArray();

    }

    IEnumerator DisableSprites()
    {
        DisableGame();
        SoundFXMananger.Instance.PlaySound(SoundType.Alien);
        foreach (GameObject sprite in spritesToDisable)
        {
            yield return new WaitForSeconds(intervaloDeTiempo);
            SoundFXMananger.Instance.PlaySound(SoundType.DisableCapsule);
            sprite.SetActive(false);
        }

        yield return new WaitForSeconds(0.2f);
        SoundFXMananger.Instance.PlaySound(SoundType.OpenDoor);
        door.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        SoundManager.Instance.EndMiniGame();
    }
}



