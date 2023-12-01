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
        // Düðmeye týklanýldýðýnda buttonText.text'i uygun bir þekilde iþleyerek bir sayýya çevir
        int buttonValue;

        if (TryParseButtonText(buttonTextSpeed.text, out buttonValue))
        {
            if (buttonValue > _coinValue.Value) return;
            // Eðer dönüþüm baþarýlýysa, _coinValue'dan çýkar
            _coinValue.Value -= buttonValue;

            // PlayerMovement scriptindeki oyuncu hareketini kontrol eden sýnýfa eriþ
            if (playerMovement != null)
            {
                // Hareket hýzýný artýr
                playerMovement.moveSpeed += 1;
                buttonValue += 100;
                buttonTextSpeed.text = buttonValue.ToString();
            }
        }
        else
        {
            // Eðer dönüþüm baþarýsýz olursa bir hata mesajý yazabilirsiniz.
            Debug.LogError("Düðme metni uygun bir sayý içermiyor.");
        }
    }

    public void CheescakeUpgrade()
    {
        int buttonValue;

        if (TryParseButtonText(buttonTextCheesecake.text, out buttonValue))
        {
            if (buttonValue > _coinValue.Value) return;
            // Eðer dönüþüm baþarýlýysa, _coinValue'dan çýkar
            _coinValue.Value -= buttonValue;

            // PlayerMovement scriptindeki oyuncu hareketini kontrol eden sýnýfa eriþ
            if (resourceGeneratorCheesecake.GenerateTime > 1)
            {
                // Hareket hýzýný artýr

                resourceGeneratorCheesecake.GenerateTime -= 1;
                buttonValue += 100;
                buttonTextCheesecake.text = buttonValue.ToString();
            }
            else if (resourceGeneratorCheesecake.GenerateTime == 1)
                buttonTextCheesecake.text = "MAX";

        }
        else
        {
            // Eðer dönüþüm baþarýsýz olursa bir hata mesajý yazabilirsiniz.
            Debug.LogError("Düðme metni uygun bir sayý içermiyor.");
        }
    }
    public void CupcakeUpgrade()
    {
        int buttonValue;

        if (TryParseButtonText(buttonTextCupcake.text, out buttonValue))
        {
            if (buttonValue > _coinValue.Value) return;
            // Eðer dönüþüm baþarýlýysa, _coinValue'dan çýkar
            _coinValue.Value -= buttonValue;

            // PlayerMovement scriptindeki oyuncu hareketini kontrol eden sýnýfa eriþ
            if (resourceGeneratorCupcake.GenerateTime > 1)
            {
                // Hareket hýzýný artýr

                resourceGeneratorCupcake.GenerateTime -= 1;
                buttonValue += 100;
                buttonTextCupcake.text = buttonValue.ToString();
            }
            else if (resourceGeneratorCupcake.GenerateTime == 1)
                buttonTextCupcake.text = "MAX";

        }
        else
        {
            // Eðer dönüþüm baþarýsýz olursa bir hata mesajý yazabilirsiniz.
            Debug.LogError("Düðme metni uygun bir sayý içermiyor.");
        }
    }
    public void MacaronUpgrade()
    {
        int buttonValue;

        if (TryParseButtonText(buttonTextMacaron.text, out buttonValue))
        {
            if (buttonValue > _coinValue.Value) return;
            // Eðer dönüþüm baþarýlýysa, _coinValue'dan çýkar
            _coinValue.Value -= buttonValue;

            // PlayerMovement scriptindeki oyuncu hareketini kontrol eden sýnýfa eriþ
            if (resourceGeneratorMacaron.GenerateTime > 1)
            {
                // Hareket hýzýný artýr

                resourceGeneratorMacaron.GenerateTime -= 1;
                buttonValue += 100;
                buttonTextMacaron.text = buttonValue.ToString();
            }
            else if (resourceGeneratorMacaron.GenerateTime == 1)
                buttonTextMacaron.text = "MAX";

        }
        else
        {
            // Eðer dönüþüm baþarýsýz olursa bir hata mesajý yazabilirsiniz.
            Debug.LogError("Düðme metni uygun bir sayý içermiyor.");
        }
    }

    private bool TryParseButtonText(string text, out int result)
    {
        // Düðme metnini uygun bir þekilde iþleyerek bir sayýya çevir
        // Bu örnekte, metindeki sayýyý alýyoruz ve boþluklarý temizleyerek sayýya dönüþtürüyoruz.
        text = text.Replace(" ", "");
        return int.TryParse(text, out result);
    }
}
