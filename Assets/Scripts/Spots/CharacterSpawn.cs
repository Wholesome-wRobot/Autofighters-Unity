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

        foreach (CharacterStats characterStats in MainController.Instance.listCharacters)
        {
            // Check for duplicate
            if (charsAlreadyInstantiated.Any(c => c.stats.uniqueId == characterStats.uniqueId))
            {
                Debug.LogError($"Character with unique id {characterStats.uniqueId} already exists. Can't spawn.");
                continue;
            }

            // Find spot
            GameObject firstSpotAvailable = GetFirstCharacterSpotAvailable(characterStats.faction);
            if (firstSpotAvailable == null)
            {
                Debug.LogError($"Alert, no spot available for {characterStats.name}");
                continue;
            }

            Debug.Log($"Instantiating {characterStats.name}");
            GameObject characterInstance = Instantiate(character, firstSpotAvailable.transform.position, Quaternion.identity);
            characterInstance.GetComponent<Character>().stats = characterStats;
            firstSpotAvailable.GetComponent<CharacterSpot>().AttachCharacter(characterStats);
        }
    }

    private GameObject GetFirstCharacterSpotAvailable(Faction faction)
    {
        GameObject[] allSpots = GameObject.FindGameObjectsWithTag("CharacterSpot");
        foreach (GameObject s in allSpots)
        {
            CharacterSpot spot = s.GetComponent<CharacterSpot>();
            if (spot.spotFaction == faction && !spot.IsOccupied)
                return s;
        }
        return null;
    }
}
