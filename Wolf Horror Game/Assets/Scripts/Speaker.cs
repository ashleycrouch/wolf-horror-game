using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogue/Speaker")]
public class Speaker : ScriptableObject
{
    public string nickname;
    public Sprite headshot;
    public void Initialize(string nickname, Sprite headshot)
    {
        this.nickname = nickname;
        this.headshot = headshot;
    }
}
