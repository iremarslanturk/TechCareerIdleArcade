using Arcade.GameResources;
using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private IntegerValue _coinValue;
    [SerializeField] private ResourceGenerator resourceGeneratorCheesecake;
    [SerializeField] private ResourceGenerator resourceGeneratorCupcake;
    [SerializeField] private ResourceGenerator resourceGeneratorMacaron;
    public TextMeshProUGUI buttonTextSpeed;
    public TextMeshProUGUI buttonTextCheesecake;
    public TextMeshProUGUI buttonTextCupcake;
    public TextMeshProUGUI buttonTextMacaron;

    public void SpeedUpgrade()
    {
        // D��meye t�klan�ld���nda buttonText.text'i uygun bir �ekilde i�leyerek bir say�ya �evir
        int buttonValue;

        if (TryParseButtonText(buttonTextSpeed.text, out buttonValue))
        {
            if (buttonValue > _coinValue.Value) return;
            // E�er d�n���m ba�ar�l�ysa, _coinValue'dan ��kar
            _coinValue.Value -= buttonValue;

            // PlayerMovement scriptindeki oyuncu hareketini kontrol eden s�n�fa eri�
            if (playerMovement != null)
            {
                // Hareket h�z�n� art�r
                playerMovement.moveSpeed += 1;
                buttonValue += 100;
                buttonTextSpeed.text = buttonValue.ToString();
            }
        }
        else
        {
            // E�er d�n���m ba�ar�s�z olursa bir hata mesaj� yazabilirsiniz.
            Debug.LogError("D��me metni uygun bir say� i�ermiyor.");
        }
    }

    public void CheescakeUpgrade()
    {
        int buttonValue;

        if (TryParseButtonText(buttonTextCheesecake.text, out buttonValue))
        {
            if (buttonValue > _coinValue.Value) return;
            // E�er d�n���m ba�ar�l�ysa, _coinValue'dan ��kar
            _coinValue.Value -= buttonValue;

            // PlayerMovement scriptindeki oyuncu hareketini kontrol eden s�n�fa eri�
            if (resourceGeneratorCheesecake.GenerateTime > 1)
            {
                // Hareket h�z�n� art�r

                resourceGeneratorCheesecake.GenerateTime -= 1;
                buttonValue += 100;
                buttonTextCheesecake.text = buttonValue.ToString();
            }
            else if (resourceGeneratorCheesecake.GenerateTime == 1)
                buttonTextCheesecake.text = "MAX";

        }
        else
        {
            // E�er d�n���m ba�ar�s�z olursa bir hata mesaj� yazabilirsiniz.
            Debug.LogError("D��me metni uygun bir say� i�ermiyor.");
        }
    }
    public void CupcakeUpgrade()
    {
        int buttonValue;

        if (TryParseButtonText(buttonTextCupcake.text, out buttonValue))
        {
            if (buttonValue > _coinValue.Value) return;
            // E�er d�n���m ba�ar�l�ysa, _coinValue'dan ��kar
            _coinValue.Value -= buttonValue;

            // PlayerMovement scriptindeki oyuncu hareketini kontrol eden s�n�fa eri�
            if (resourceGeneratorCupcake.GenerateTime > 1)
            {
                // Hareket h�z�n� art�r

                resourceGeneratorCupcake.GenerateTime -= 1;
                buttonValue += 100;
                buttonTextCupcake.text = buttonValue.ToString();
            }
            else if (resourceGeneratorCupcake.GenerateTime == 1)
                buttonTextCupcake.text = "MAX";

        }
        else
        {
            // E�er d�n���m ba�ar�s�z olursa bir hata mesaj� yazabilirsiniz.
            Debug.LogError("D��me metni uygun bir say� i�ermiyor.");
        }
    }
    public void MacaronUpgrade()
    {
        int buttonValue;

        if (TryParseButtonText(buttonTextMacaron.text, out buttonValue))
        {
            if (buttonValue > _coinValue.Value) return;
            // E�er d�n���m ba�ar�l�ysa, _coinValue'dan ��kar
            _coinValue.Value -= buttonValue;

            // PlayerMovement scriptindeki oyuncu hareketini kontrol eden s�n�fa eri�
            if (resourceGeneratorMacaron.GenerateTime > 1)
            {
                // Hareket h�z�n� art�r

                resourceGeneratorMacaron.GenerateTime -= 1;
                buttonValue += 100;
                buttonTextMacaron.text = buttonValue.ToString();
            }
            else if (resourceGeneratorMacaron.GenerateTime == 1)
                buttonTextMacaron.text = "MAX";

        }
        else
        {
            // E�er d�n���m ba�ar�s�z olursa bir hata mesaj� yazabilirsiniz.
            Debug.LogError("D��me metni uygun bir say� i�ermiyor.");
        }
    }

    private bool TryParseButtonText(string text, out int result)
    {
        // D��me metnini uygun bir �ekilde i�leyerek bir say�ya �evir
        // Bu �rnekte, metindeki say�y� al�yoruz ve bo�luklar� temizleyerek say�ya d�n��t�r�yoruz.
        text = text.Replace(" ", "");
        return int.TryParse(text, out result);
    }
}
