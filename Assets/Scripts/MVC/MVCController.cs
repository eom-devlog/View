using UnityEngine;

public class MVCController
{
    private MVCModel model;
    private MVCView view;

    public MVCController(MVCModel model, MVCView view)
    {
        this.model = model;
        this.view = view;

        // 모델 변경 시 뷰 업데이트
        model.OnHpChanged += view.UpdateHp;

        // 초기 동기화
        view.UpdateHp(model.GetHp(), model.MaxHp);
    }

    public void HandleDamage(int amount)
    {
        model.TakeDamage(amount);
    }

    public void HandleHeal(int amount)
    {
        model.Heal(amount);
    }

    public void Dispose()
    {
        model.OnHpChanged -= view.UpdateHp;
    }
}
