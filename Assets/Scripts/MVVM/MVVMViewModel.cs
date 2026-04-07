using System;
using System.ComponentModel;

public class MVVMViewModel : INotifyPropertyChanged //객체가 속성의 변경을 클라이언트에 알리고, UI가 동적으로 업데이트 되도록 할수 있다.
{
    private readonly MVVMModel model;

    //속성이 변경될 때마다 발생한다.
    public event PropertyChangedEventHandler PropertyChanged;

    public MVVMViewModel(MVVMModel model) => this.model = model;

    public int Value
    {
        get => model.Value;
        set
        {
            if (model.Value == value) return;
            model.Value = value;
            OnPropertyChanged(nameof(Value));
            OnPropertyChanged(nameof(DisplayText)); // 파생 속성 갱신
        }
    }

    public string DisplayText => $"Count: {Value}";
    public void Increment(int amount = 1) => Value += amount;
    public void Decrement(int amount = 1) => Value -= amount;
    protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
