using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    [CreateAssetMenu(fileName = "StatsDatabase", menuName = "Other/StatsDatabase")]
    public class SO_StatsDB : ScriptableObject
    {
        [SerializeField] private List<SO_CharacterStats> _statsList;
        public List<SO_CharacterStats> StatsList { get => _statsList; private set => _statsList = value; }
    }
}
