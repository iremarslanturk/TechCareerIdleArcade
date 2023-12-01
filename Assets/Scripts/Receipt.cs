using UnityEngine;

namespace Arcade.GameResources
{
    [CreateAssetMenu(fileName = "New Receipt", menuName = "Arcade/Receipt")]
    public class Receipt : ScriptableObject
    {
        public ResourceItem _ResourceItem;

        public ResourceItem GetResourceItem()
        {
            return _ResourceItem;
        }
    }
}

