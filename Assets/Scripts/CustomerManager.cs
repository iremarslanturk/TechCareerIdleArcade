using System.Collections.Generic;
using UnityEngine;

namespace Arcade.GameResources
{
    public class CustomerManager : MonoBehaviour
    {
        public List<ResourceGenerator> generators; // Bu listeye üç ResourceGenerator'ý atayýn.

        private ResourceGenerator currentGenerator;
        private ResourceItem requestedItem;

        private void Start()
        {
            RequestRandomItem();
            LogCurrentRequest();

        }

        private void Update()
        {
            if (currentGenerator != null && currentGenerator.HoldingItem == requestedItem)
            {
                // Kullanýcý doðru ürünü aldý, yeni bir talep oluþtur.
                RequestRandomItem();
            }
        }

        private void RequestRandomItem()
        {
            // Rastgele bir üretici ve talep edilen ürün seç.
            currentGenerator = GetRandomGenerator();

            // Seçilen üreticiye talep gönder.
            currentGenerator.SetReceipt(currentGenerator._receipt);
            currentGenerator.Restart();
        }


        private ResourceGenerator GetRandomGenerator()
        {
            // Üç üretici arasýndan rastgele birini seç.
            int randomIndex = Random.Range(0, generators.Count);
            return generators[randomIndex];
        }
        private void LogCurrentRequest()
        {
            if (requestedItem != null)
            {
                Debug.Log($"Customer requested: {requestedItem.name}");
            }
            else
            {
                Debug.Log("No current request.");
            }
        }

    }
}
