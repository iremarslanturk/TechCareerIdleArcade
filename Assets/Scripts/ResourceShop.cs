using Arcade.GameResources;
using UnityEngine;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Arcade
{
    public class ResourceShop : MonoBehaviour
    {
        [SerializeField] private IntegerValue _coinValue;
        [SerializeField] private Transform _generatePoint;
        [SerializeField] public Receipt _receipt;
        [SerializeField] private float _generateTime;
        private Action m_currentBehaviour;

        private float m_timer;
        private float m_waitTimer; // Yeni item talep etmeden �nce beklenen s�reyi takip eden saya�
        public ResourceItem HoldingItem { get; set; }
        private bool canSellItem = true; // Yeni item sat�labilir durumunda m� kontrol�

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerInteraction player)) return;

            if (player.HoldingItem != null && canSellItem)
            {
                Debug.Log(player.HoldingItem);
                Debug.Log(_receipt._ResourceItem);

                // Compare by item name without considering "(clone)"
                string playerItemName = player.HoldingItem.name;
                string _playerItemName = playerItemName.Substring(0, playerItemName.Length - 7);
                string receiptItemName = _receipt._ResourceItem.name;
                string _receiptItemName = receiptItemName.Substring(0, receiptItemName.Length);

                Debug.Log(_playerItemName);
                Debug.Log(_receiptItemName);

                if (_playerItemName == _receiptItemName)
                {
                    canSellItem = false; // Sat�� yap�ld���nda yeni item sat��a haz�r de�il
                    SellItem(player.HoldingItem);
                    Destroy(player.HoldingItem.gameObject);
                    Destroy(HoldingItem.gameObject);
                }
            }
        }

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
                m_waitTimer = 0; // Yeni �r�n talep etmeden �nce beklenen s�reyi s�f�rla
                canSellItem = true; // Yeni �r�n talep edilebilir duruma getir
                m_currentBehaviour = IdleBehaviour;
            }
        }



        private void GenerateItem()
        {
            canSellItem = true; // Yeni item �retildi�inde canSellItem'� true yap
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

        private void SellItem(ResourceItem item)
        {
            Debug.Log($"Sold item for {item._goldValue} gold");
            _coinValue.Value += item._goldValue;
            Destroy(item.gameObject);

            // Sat�� sonras�nda beklenen s�reyi ba�lat
            m_currentBehaviour = WaitBeforeNextRequest;
        }

        private void WaitBeforeNextRequest()
        {
            StartGenerator(); // Yeni �r�n talep etme d�ng�s�n� hemen ba�lat
        }


    }
}
