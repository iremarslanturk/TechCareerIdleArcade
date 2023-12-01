using System;
using UnityEngine;
using UnityEngine.UI;

namespace Arcade.GameResources
{
    public class ResourceGenerator : MonoBehaviour
    {
        [SerializeField] public Receipt _receipt;
        [SerializeField] private Transform _generatePoint;
        [SerializeField] private float _generateTime;

        public float GenerateTime
        {
            get { return _generateTime; }
            set { _generateTime = value; }
        }


        private Action m_currentBehaviour;

        private float m_timer;
        public ResourceItem HoldingItem { get; set; }


        private void Start()
        {

            StartGenerator();
        }

        private void Update()
        {
            m_currentBehaviour?.Invoke();
        }

        private void GenerateBehaviour()
        {
            if (m_timer < _generateTime)
            {
                m_timer += Time.deltaTime;
                
            }
            else
            {
                GenerateItem();
                m_timer = 0;
                m_currentBehaviour = IdleBehaviour;
            }
        }

        private void GenerateItem()
        {

            HoldingItem = Instantiate(_receipt._ResourceItem, _generatePoint.position, Quaternion.identity);
        }

        private void StartGenerator()
        {
            m_currentBehaviour = GenerateBehaviour;
        }

        private void IdleBehaviour()
        {
            m_currentBehaviour = null;
        }

        public void Restart()
        {
            StartGenerator();
        }

        public void SetReceipt(Receipt receipt)
        {
            _receipt = receipt;
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }


    }
}
