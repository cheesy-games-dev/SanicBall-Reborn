using Sanicball.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "Dynamic Data", menuName = "Sanicball/Dynamic Data", order = 100)]
public class DynamicData : ScriptableObject
{
    [SerializeField]
    private StageData[] stages;

    [SerializeField]
    private CharacterData[] characters;

    [SerializeField]
    private CharacterDependantPlaylists characterSpecificMusic;
}
