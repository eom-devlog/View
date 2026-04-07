using System;

public class MVVMModel
{
    private int value;
    public int Value
    {
        get => value;
        set => this.value = value;
    }

    public MVVMModel(int initial = 0) => value = initial;
    
}
