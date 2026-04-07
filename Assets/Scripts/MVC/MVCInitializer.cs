using UnityEngine;

public class MVCInitializer : MonoBehaviour
{
    [SerializeField] private MVCView view;
    [SerializeField] private int playerMaxHp = 100;
    [SerializeField] private int playerMaxDamage = 20;
    [SerializeField] private int playerMaxHeal = 20;

    private MVCModel model;
    private MVCController controller;

    void Start()
    {
        model = new MVCModel(playerMaxHp);
        controller = new MVCController(model, view);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // 데미지
            controller.HandleDamage(Random.Range(1,playerMaxDamage));

        if (Input.GetKeyDown(KeyCode.S)) // 회복
            controller.HandleHeal(Random.Range(1,playerMaxHeal));
    }

    void OnDestroy()
    {
        controller?.Dispose();
    }
}
