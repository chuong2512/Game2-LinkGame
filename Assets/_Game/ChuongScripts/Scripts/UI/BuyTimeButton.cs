using ChuongCustom;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyTimeButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private int _index;

    public int Index
    {
        get => _index;
        set => _index = value;
    }

    private int _timer;

    private void OnValidate()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetDataWithIndex();

        _button?.onClick.AddListener(OnClickButton);
    }

    private void SetDataWithIndex()
    {
        switch (_index)
        {
            case 0:
                _text.SetText("1 day");
                _timer = 0;
                break;
            case 1:
                _text.SetText("7 days");
                _timer = 0;
                break;
            case 2:
                _text.SetText("30 days");
                _timer = 0;
                break;
            case 3:
                _text.SetText("3 months");
                _timer = 0;
                break;
            case 4:
                _text.SetText("6 months");
                _timer = 0;
                break;
        }
    }

    private void OnClickButton()
    {
        MasterAudioManager.ClickSound();
        /*switch (_index)
        {
            case 0:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(1);
                IAPManager.Instance.BuyProductID(IAPKey.PACK1_REGISTER);
                break;
            case 1:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(7);
                IAPManager.Instance.BuyProductID(IAPKey.PACK2_REGISTER);
                break;
            case 2:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(30);
                IAPManager.Instance.BuyProductID(IAPKey.PACK3_REGISTER);
                break;
            case 3:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(90);
                IAPManager.Instance.BuyProductID(IAPKey.PACK4_REGISTER);
                break;
            case 4:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(180);
                IAPManager.Instance.BuyProductID(IAPKey.PACK5_REGISTER);
                break;
        }*/
    }

    private void AddTime(int time)
    {
        GameAction.SetRegisterTime.Invoke(time);
    }
}