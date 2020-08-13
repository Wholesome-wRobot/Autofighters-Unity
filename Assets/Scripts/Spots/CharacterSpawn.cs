using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject character;

    public void InstantiateControllerCharacters()
    {
        // Create array of already instantiated characters
        Character[] charsAlreadyInstantiated = FindObjectsOfType<Character>();

        foreach (CharacterStats characterStats in MainController.Instance.GetListAllCharacters())
        {
            // Check for duplicate
            if (charsAlreadyInstantiated.Any(c => c.Stats.UniqueId == characterStats.UniqueId))
            {
                Debug.LogError($"Character with unique id {characterStats.UniqueId} already exists. Can't spawn.");
                continue;
            }

            // Find spot
            CharacterSpot firstSpotAvailable = GetFirstCharacterSpotAvailable(characterStats.Faction);
            if (firstSpotAvailable == null)
            {
                Debug.LogError($"Alert, no spot available for {characterStats.DisplayName}");
                continue;
            }

            // Instantiate
            Debug.Log($"Instantiating {characterStats.DisplayName}");
            Character characterInstance = Instantiate(Resources.Load<Character>("Prefabs/Character"), firstSpotAvailable.transform.position, Quaternion.identity);

            // Load stats into new character
            characterInstance.GetComponent<Character>().LoadStats(characterStats);

            // Attach character to spot
            firstSpotAvailable.GetComponent<CharacterSpot>().AttachCharacter(characterStats);
        }
    }

    private CharacterSpot GetFirstCharacterSpotAvailable(Faction faction)
    {
        List<CharacterSpot> allSpots = FindObjectsOfType<CharacterSpot>().OrderBy(o => o.id).ToList();

        foreach (CharacterSpot spot in allSpots)
        {
            if (spot.spotFaction == faction && !spot.IsOccupied)
                return spot;
        }
        return null;
    }
}
