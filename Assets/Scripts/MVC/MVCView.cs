using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MVCView : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] private Slider hpSlider;

    //뷰는 모델의 상태를 받아서 화면을 업데이트만 함
    public void UpdateHp(int current, int max)
    {
        if (hpText != null) hpText.text = $"HP: {current}/{max}";
        if (hpSlider != null)
        {
            hpSlider.maxValue = max;
            hpSlider.value = current;
        }
    }
}
