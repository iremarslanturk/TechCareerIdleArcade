using System.Collections.Generic;
using UnityEngine;

namespace Arcade.GameResources
{
    public class CustomerManager : MonoBehaviour
    {
        public List<ResourceGenerator> generators; // Bu listeye �� ResourceGenerator'� atay�n.

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
                // Kullan�c� do�ru �r�n� ald�, yeni bir talep olu�tur.
                RequestRandomItem();
            }
        }

        private void RequestRandomItem()
        {
            // Rastgele bir �retici ve talep edilen �r�n se�.
            currentGenerator = GetRandomGenerator();

            // Se�ilen �reticiye talep g�nder.
            currentGenerator.SetReceipt(currentGenerator._receipt);
            currentGenerator.Restart();
        }


        private ResourceGenerator GetRandomGenerator()
        {
            // �� �retici aras�ndan rastgele birini se�.
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
