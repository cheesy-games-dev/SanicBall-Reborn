using Sanicball;
using Sanicball.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "Dynamic Data", menuName = "Sanicball/Dynamic Data", order = 100)]
public class DynamicData : ScriptableObject
{
    public StageData[] stages;

    public CharacterData[] characters;

    public CharacterDependantPlaylists characterSpecificMusic;

    public AudioClip[] songs;
}
