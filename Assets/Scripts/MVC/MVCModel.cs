using System;

public class MVCModel
{
    private int hp;
    public int MaxHp { get; private set; }

    public event Action<int, int> OnHpChanged; //(currentHp, maxHp)

    public MVCModel(int maxHp)
    {
        MaxHp = maxHp;
        hp = MaxHp;
    }

    public int GetHp() => hp;

    public void TakeDamage(int amount)
    {
        hp = System.Math.Max(0, hp - amount);
        OnHpChanged?.Invoke(hp, MaxHp);
    }

    public void Heal(int amount)
    {
        hp = System.Math.Min(MaxHp, hp + amount);
        OnHpChanged?.Invoke(hp, MaxHp);
    }

    public void SetHp(int value)
    {
        hp = System.Math.Clamp(value, 0, MaxHp);
        OnHpChanged?.Invoke(hp, MaxHp);
    }
}
