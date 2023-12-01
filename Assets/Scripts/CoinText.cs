using TMPro;
using UnityEngine;

namespace Arcade.UI
{
    public class CoinText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textComponent;
        [SerializeField] private IntegerValue _coinValue;

        private void Start()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            _textComponent.text = _coinValue.Value.ToString();
        }

        private void OnEnable()
        {
            _coinValue.SubscribeToValueChanged(UpdateText);
        }

        private void OnDisable()
        {
            _coinValue.UnsubscribeToValueChanged(UpdateText);
        }
    }
}