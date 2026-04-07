using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class MVPView : MonoBehaviour
{
    [SerializeField] private Text counterText;
    [SerializeField] private Button incrementButton;
    [SerializeField] private Button decrementButton;

    public event Action OnIncrementClicked;
    public event Action OnDecrementClicked;

    private void Awake()
    {
        if (incrementButton != null) incrementButton.onClick.AddListener(() => OnIncrementClicked?.Invoke());
        if (decrementButton != null) decrementButton.onClick.AddListener(() => OnDecrementClicked?.Invoke());
    }

    public void SetCounterText(string text)
    {
        if (counterText != null) counterText.text = text;
    }

    private void OnDestroy()
    {
        if (incrementButton != null) incrementButton.onClick.RemoveAllListeners();
        if (decrementButton != null) decrementButton.onClick.RemoveAllListeners();
    }
}
