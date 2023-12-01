using System;
using ScriptableObjects;
using UnityEngine;

namespace Arcade
{
    public class UpgradeShop : MonoBehaviour
    {
        [SerializeField] private float _openTime;
        [SerializeField] private ScriptableBoolEvent _toggleUpgradePanel;

        private Action m_currentBehaviour;
        private float m_timer;
        private void Update()
        {
            m_currentBehaviour?.Invoke();
        }

        private void LoadingBehaviour()
        {
            if (m_timer < _openTime)
            {
                m_timer += Time.deltaTime;
            }
            else
            {
                OpenPanel();
                IdleBehaviour();
            }
        }

        private void OpenPanel()
        {
            _toggleUpgradePanel.InvokeAction(true);
        }

        private void ClosePanel()
        {
            _toggleUpgradePanel.InvokeAction(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerInteraction _)) return;

            StartToOpen();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out PlayerInteraction _)) return;

            ClosePanel();
            IdleBehaviour();
        }

        private void StartToOpen()
        {
            m_currentBehaviour = LoadingBehaviour;
        }

        private void IdleBehaviour()
        {
            m_timer = 0;
            m_currentBehaviour = null;
        }
    }
}