using UnityEngine;

namespace AutoFighters
{
    public class Database : MonoBehaviour
    {
        [SerializeField] public ItemDB _itemDB;
        [SerializeField] public SO_StatsDB _statsDB;

        private static Database Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static Item CreateItemSO(ItemId itemId)
        {
            Item item = Instance._itemDB.ItemList.Find(i => i.ItemId == itemId);
            return Instantiate(item);
        }

        public static SO_CharacterStats GetCharacterSOByArchetype(CharacterArchetype archetype)
        {
            SO_CharacterStats result = Instance._statsDB.StatsList.Find(s => s.CharacterArchetype == archetype);
            if (result == null)
                Debug.LogError("Archetype " + archetype.ToString() + " introuvable dans la DB");
            return result;
        }
    }
}
