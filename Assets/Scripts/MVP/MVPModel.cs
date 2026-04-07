using System;

public class MVPModel
{
    private int value;
    public int Value => value;

    public event Action<int> OnValueChanged;

    public MVPModel(int initial = 0)
    {
        value = initial;
    }

    public void Increment(int amount = 1)
    {
        value += amount;
        OnValueChanged?.Invoke(value);
    }

    public void Decrement(int amount = 1)
    {
        value -= amount;
        OnValueChanged?.Invoke(value);
    }

    public void Set(int newValue)
    {
        value = newValue;
        OnValueChanged?.Invoke(value);
    }
}
