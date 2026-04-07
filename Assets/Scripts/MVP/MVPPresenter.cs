using System;

public class MVPPresenter
{
    private readonly MVPModel model;
    private readonly MVPView view;

    public MVPPresenter(MVPModel model, MVPView view)
    {
        this.model = model;
        this.view = view;

        // 초기값 표시
        view.SetCounterText(model.Value.ToString());

        // 이벤트 연결
        model.OnValueChanged += OnModelValueChanged;
        view.OnIncrementClicked += OnIncrement;
        view.OnDecrementClicked += OnDecrement;
    }

    private void OnModelValueChanged(int newValue)
    {
        view.SetCounterText(newValue.ToString());
    }

    private void OnIncrement()
    {
        model.Increment();
    }

    private void OnDecrement()
    {
        model.Decrement();
    }

    public void Dispose()
    {
        model.OnValueChanged -= OnModelValueChanged;
        view.OnIncrementClicked -= OnIncrement;
        view.OnDecrementClicked -= OnDecrement;
    }
}
