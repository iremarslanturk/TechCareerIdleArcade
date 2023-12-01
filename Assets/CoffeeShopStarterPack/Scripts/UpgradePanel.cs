using System;
using ScriptableObjects;
using UnityEngine;

namespace Arcade.UI
{
    public class UpgradePanel : MonoBehaviour
    {
        [SerializeField] private ScriptableBoolEvent _toggleUpgradePanel;
        [SerializeField] private GameObject _upgradePanel;

        private void Start()
        {
            _upgradePanel.SetActive(false);
        }

        private void TogglePanel(bool toggle)
        {
            _upgradePanel.SetActive(toggle);
        }

        private void OnEnable()
        {
            _toggleUpgradePanel.Subscribe(TogglePanel);
        }

        private void OnDisable()
        {
            _toggleUpgradePanel.Unsubscribe(TogglePanel);
        }
    }
}