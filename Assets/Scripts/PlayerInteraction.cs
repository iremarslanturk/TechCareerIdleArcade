using Arcade.GameResources;
using UnityEngine;

namespace Arcade
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform _holdingPoint;

        public ResourceItem HoldingItem { get; set; }
        private void OnTriggerEnter(Collider other)
        {
            if (HoldingItem != null) return;

            if (!other.TryGetComponent(out ResourceGenerator generator)) return;

            GetItem(generator);
        }

        private void GetItem(ResourceGenerator generator)
        {
            if (generator.HoldingItem == null) return;

            generator.HoldingItem.transform.position = _holdingPoint.position;
            generator.HoldingItem.transform.parent = _holdingPoint;
            HoldingItem = generator.HoldingItem;
            generator.HoldingItem = null;
            generator.Restart();
        }
    }
}