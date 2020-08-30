using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    [System.Serializable]
    public class SerializedItem
    {
        [SerializeField] private ItemId _itemId;
        public ItemId ItemId { get => _itemId; private set => _itemId = value; }

        [SerializeField] private List<ItemId> _runeList;
        public List<ItemId> RuneList { get => _runeList; private set => _runeList = value; }

        public SerializedItem (Item item)
        {
            if (item == null)
                ItemId = ItemId.None;
            else
            {
                ItemId = item.ItemId;
                RuneList = new List<ItemId>();

                // Spell
                if (item is Spell)
                {
                    Spell spell = item as Spell;
                    for (int i = 0; i < spell.RuneList.Count; i++)
                    {
                        if (spell.RuneList[i] != null)
                            RuneList.Add(spell.RuneList[i].ItemId);
                        else
                            RuneList.Add(ItemId.None);
                    }
                }
                // Rune
                else
                {
                    RuneList = null;
                }
            }
        }

        public Item Deserialize()
        {
            if (ItemId == ItemId.None) return null;

            Item item = Database.CreateItemSO(ItemId);

            // Spell
            if (item is Spell)
            {
                Spell spell = item as Spell;
                foreach(ItemId id in RuneList)
                {
                    if (id != ItemId.None)
                        spell.AddRune(Database.CreateItemSO(id) as Rune);
                }
                return spell;
            }
            // Rune
            else
            {
                return Database.CreateItemSO(ItemId) as Rune;
            }
        }
    }
}
