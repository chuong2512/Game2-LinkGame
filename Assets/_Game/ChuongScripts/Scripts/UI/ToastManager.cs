using ChuongCustom;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class ToastManager : Singleton<ToastManager>
{
    [SerializeField] private RectTransform _rectTrans;

    [SerializeField] private Text _tmpToast;

    [FoldoutGroup("Color Toast")] public Color _messageColor;
    [FoldoutGroup("Color Toast")] public Color _warningColor;

    private readonly Vector2 _startPos = new Vector2(0, 200);

    private Sequence _sequence;

    public void ShowToast(string toastMessage, Color colorMessage, float duration = 0.4f, float interval = 0.4f)
    {
        _tmpToast.text = (toastMessage);
        _tmpToast.color = colorMessage;

        _sequence.Kill();
        _rectTrans.DOKill();

        _rectTrans.anchoredPosition = _startPos;
        _rectTrans.localScale = Vector3.zero;
        _rectTrans.gameObject.SetActive(true);

        _sequence = DOTween.Sequence();

        _sequence.Append(_rectTrans.DOScale(1, 0.05f))
            .Append(_rectTrans.DOAnchorPosY(300, duration))
            .AppendInterval(interval)
            .OnComplete(() => _rectTrans.gameObject.SetActive(false));
    }

    public void ShowMessageToast(string toastMessage, float duration = 0.4f, float interval = 0.4f)
    {
        ShowToast(toastMessage, _messageColor, duration, interval);
    }

    public void ShowWarningToast(string toastMessage, float duration = 0.4f, float interval = 0.4f)
    {
        ShowToast(toastMessage, _warningColor, duration, interval);
    }
}