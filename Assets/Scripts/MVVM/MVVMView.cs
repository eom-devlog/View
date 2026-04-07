using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class MVVMView : MonoBehaviour
{
    [SerializeField] private Text displayText;
    [SerializeField] private Button incrementButton;
    [SerializeField] private Button decrementButton;
    [SerializeField] private InputField inputField;

    private MVVMViewModel viewModel;

    public void Bind(MVVMViewModel vm)
    {
        Unbind();
        viewModel = vm;

        //초기 표시
        if (displayText != null) displayText.text = viewModel.DisplayText;
        if (inputField != null) inputField.text = viewModel.Value.ToString();

        //구독: ViewModel 변경을 UI에 반영
        viewModel.PropertyChanged += OnViewModelPropertyChanged;

        //UI 이벤트 -> ViewModel 호출 (양방향)
        if (incrementButton != null) incrementButton.onClick.AddListener(() => viewModel.Increment());
        if (decrementButton != null) decrementButton.onClick.AddListener(() => viewModel.Decrement());
        if (inputField != null) inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
    }

    private void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MVVMViewModel.Value) || e.PropertyName == nameof(MVVMViewModel.DisplayText))
        {
            if (displayText != null) displayText.text = viewModel.DisplayText;
            if (inputField != null) inputField.text = viewModel.Value.ToString();
        }
    }

    private void OnInputFieldEndEdit(string text)
    {
        if (int.TryParse(text, out int v))
            viewModel.Value = v;
        else
            inputField.text = viewModel.Value.ToString(); // 유효하지 않으면 원래값 복원
    }

    public void Unbind()
    {
        if (viewModel != null)
        {
            viewModel.PropertyChanged -= OnViewModelPropertyChanged;
            if (incrementButton != null) incrementButton.onClick.RemoveAllListeners();
            if (decrementButton != null) decrementButton.onClick.RemoveAllListeners();
            if (inputField != null) inputField.onEndEdit.RemoveAllListeners();
            viewModel = null;
        }
    }

    private void OnDestroy() => Unbind();
}
