using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AutoFighters
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private List<CharacterStats> _characterList;
        public List<CharacterStats> CharacterList { get => _characterList; private set => _characterList = value; }

        private readonly int _maxNumberOfAllies = 4;

        public void AddCharacterToList(CharacterStats characterStats)
        {
            if (characterStats.Faction == Faction.Ally && GetListAllies().Count < _maxNumberOfAllies)
                CharacterList.Add(characterStats);
            else if (characterStats.Faction == Faction.Enemy)
                CharacterList.Add(characterStats);
        }

        public void SetCharactersList(List<CharacterStats> list) { CharacterList = list; }

        public List<CharacterStats> GetListAllies()
        {
            return CharacterList.Where(s => s.Faction == Faction.Ally).ToList();
        }

        public List<CharacterStats> GetListEnemies()
        {
            return CharacterList.Where(s => s.Faction == Faction.Enemy).ToList();
        }

        public void ClearCharacterList()
        {
            CharacterList.Clear();
        }

        public void RemoveFromList(CharacterStats characterStats)
        {
            CharacterList.Remove(characterStats);
        }
    }
}
