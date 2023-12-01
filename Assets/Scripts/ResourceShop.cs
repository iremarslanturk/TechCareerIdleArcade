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
        private float m_waitTimer; // Yeni item talep etmeden önce beklenen süreyi takip eden sayaç
        public ResourceItem HoldingItem { get; set; }
        private bool canSellItem = true; // Yeni item satýlabilir durumunda mý kontrolü

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
                    canSellItem = false; // Satýþ yapýldýðýnda yeni item satýþa hazýr deðil
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
                m_waitTimer = 0; // Yeni ürün talep etmeden önce beklenen süreyi sýfýrla
                canSellItem = true; // Yeni ürün talep edilebilir duruma getir
                m_currentBehaviour = IdleBehaviour;
            }
        }



        private void GenerateItem()
        {
            canSellItem = true; // Yeni item üretildiðinde canSellItem'ý true yap
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

            // Satýþ sonrasýnda beklenen süreyi baþlat
            m_currentBehaviour = WaitBeforeNextRequest;
        }

        private void WaitBeforeNextRequest()
        {
            StartGenerator(); // Yeni ürün talep etme döngüsünü hemen baþlat
        }


    }
}
