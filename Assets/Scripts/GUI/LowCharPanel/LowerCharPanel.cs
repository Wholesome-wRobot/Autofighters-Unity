using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AutoFighters
{
    public class LowerCharPanel : MonoBehaviour
    {
        private GridLayoutGroup _grid;
        private readonly int numberOfIndividualPanels = 4;

        public IndividualLowPanel individualLowPanelPrefab;

        [SerializeField] private List<IndividualLowPanel> _individualLowPanels;
        public List<IndividualLowPanel> IndividualLowPanels { get => _individualLowPanels; set => _individualLowPanels = value; }

        void Awake()
        {
            _grid = GetComponentInChildren<GridLayoutGroup>();

            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            IndividualLowPanels = new List<IndividualLowPanel>();
            for (int i = 0; i < numberOfIndividualPanels; i++)
            {
                IndividualLowPanel panel = Instantiate(individualLowPanelPrefab);
                panel.transform.SetParent(_grid.GetComponent<Transform>(), false);
                panel.SetIndex(i);
                IndividualLowPanels.Add(panel);
            }
        }

        public IndividualLowPanel GetFirstFreePanel()
        {
            foreach (IndividualLowPanel panel in IndividualLowPanels)
            {
                if (panel.AttachedCharacter == null)
                    return panel;
            }
            Debug.LogError("NO FREE PANEL FOUND");
            return null;
        }

        public void DetachAllCharacters()
        {
            foreach (IndividualLowPanel indPanel in IndividualLowPanels)
                indPanel.DetachCharacter();
        }
    }
}