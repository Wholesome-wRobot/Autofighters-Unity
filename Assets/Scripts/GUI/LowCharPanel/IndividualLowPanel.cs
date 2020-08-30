using AutoFighters;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndividualLowPanel : MonoBehaviour
{
    private TextMeshProUGUI _characterNameText;
    private GridLayoutGroup _grid;

    public LowPanelSpellSlot spellSlotPrefab;

    [SerializeField] private CharacterStats _attachedCharacter;
    public CharacterStats AttachedCharacter { get => _attachedCharacter; private set => _attachedCharacter = value; }

    [SerializeField] private List<LowPanelSpellSlot> _spellSlots;
    public List<LowPanelSpellSlot> SpellSlots { get => _spellSlots; private set => _spellSlots = value; }

    [SerializeField] private int _index;
    public int Index { get => _index; private set => _index = value; }

    void Awake()
    {
        _characterNameText = GetComponentInChildren<TextMeshProUGUI>();
        _grid = GetComponentInChildren<GridLayoutGroup>();
    }

    void Start()
    {
        AttachedCharacter = null;

        // Adding Spellslots prefabs
        SpellSlots = new List<LowPanelSpellSlot>();
        for (int i = 0; i < Consts.NbOfSpellsPerCharacter; i++)
        {
            LowPanelSpellSlot slot = Instantiate(spellSlotPrefab);
            slot.transform.SetParent(_grid.GetComponent<RectTransform>(), false);
            slot.SetIndex(i);
            slot.SetMyIndividualPanel(this);
            SpellSlots.Add(slot);
        }
    }

    public void SetCharacterName(string name)
    {
        _characterNameText.SetText(name);
    }

    public void AttachCharacter(CharacterStats stats)
    {
        stats.SetMyLowCharacterPanel(this);
        AttachedCharacter = stats;
        // Attach his spells
        for (int i = 0; i < stats.SpellSlots.Count; i++)
            SpellSlots[i].SetItem(stats.SpellSlots[i]);
    }

    public void DetachCharacter()
    {
        Debug.Log("Dettaching individual panel " + Index);
        AttachedCharacter = null;
        SetCharacterName("Empty");
        foreach (LowPanelSpellSlot slot in SpellSlots)
            slot.SetItem(null);
    }

    public void SetIndex(int index)
    {
        Index = index;
    }
}
