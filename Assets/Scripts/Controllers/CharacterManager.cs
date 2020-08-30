using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AutoFighters
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private List<CharacterStats> _characterList;
        public List<CharacterStats> CharacterList { get => _characterList; private set => _characterList = value; }

        public bool AddCharacterToList(CharacterStats characterStats) 
        {
            // Add ally
            Debug.Log($"Adding {characterStats.DisplayName} to character list");
            if (characterStats.Faction == Faction.Ally)
            {
                if (GetListAllies().Count >= Consts.MaxNumberOfAllies)
                {
                    Debug.LogError("NO MORE ROOM FOR ALLIES");
                    return false;
                }
                MainController.Instance.LowerCharPanel.GetFirstFreePanel().AttachCharacter(characterStats);
                CharacterList.Add(characterStats);
            }
            // Add enemy
            else if (characterStats.Faction == Faction.Enemy)
            {
                if (GetListEnemies().Count >= Consts.MaxNumberOfEnemies)
                {
                    Debug.LogError("NO MORE ROOM FOR ENEMIES");
                    return false;
                }
                CharacterList.Add(characterStats);
            }
            return true;
        }

        public void LoadCharacterListFromSave(List<SerializedCharacterStats> statsList)
        {
            // Delete existing stats
            foreach (CharacterStats stats in CharacterList)
            {
                if (stats.Faction == Faction.Ally)
                    stats.MyLowCharacterPanel.DetachCharacter();
            }

            CharacterList.Clear();

            // Replace by new
            foreach (SerializedCharacterStats stats in statsList)
                AddCharacterToList(stats.Deserialize());
        }

        public List<CharacterStats> GetListAllies()
        {
            return CharacterList.Where(s => s.Faction == Faction.Ally).ToList();
        }

        public List<CharacterStats> GetListEnemies()
        {
            return CharacterList.Where(s => s.Faction == Faction.Enemy).ToList();
        }
    }
}
