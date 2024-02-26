using ChuongCustom;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyCoinButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private int _index;

    public int Index
    {
        get => _index;
        set
        {
            _index = value;
            SetDataWithIndex();
        }
    }

    private int bullet;

    private void OnValidate()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        _button?.onClick.AddListener(OnClickButton);
    }

    private void SetDataWithIndex()
    {
        switch (_index)
        {
            case 0:
                bullet = 10;
                break;
            case 1:
                bullet = 20;
                break;
            case 2:
                bullet = 30;
                break;
            case 3:
                bullet = 50;
                break;
            case 4:
                bullet = 100;
                break;
        }

        _text.SetText($" +{bullet} <sprite=0>");
    }

    private void OnClickButton()
    {
        MasterAudioManager.ClickSound();

        /*IAPManager.OnPurchaseSuccess = AddCoin;

        switch (_index)
        {
            case 0:
                IAPManager.Instance.BuyProductID(IAPKey.PACK1);
                break;
            case 1:
                IAPManager.Instance.BuyProductID(IAPKey.PACK2);
                break;
            case 2:
                IAPManager.Instance.BuyProductID(IAPKey.PACK3);
                break;
            case 3:
                IAPManager.Instance.BuyProductID(IAPKey.PACK4);
                break;
            case 4:
                IAPManager.Instance.BuyProductID(IAPKey.PACK5);
                break;
        }*/
    }

    private void AddCoin()
    {
    }
}