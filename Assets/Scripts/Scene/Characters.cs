using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
public class Characters : ScriptableObject
{
    public GameObject Character;
    public Sprite imagen;
    public string nombre;
}
