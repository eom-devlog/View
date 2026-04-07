using UnityEngine;

public class MVPInitializer : MonoBehaviour
{
    [SerializeField] private MVPView counterView;
    [SerializeField] private int initialValue = 0;

    private MVPModel model;
    private MVPPresenter presenter;

    void Start()
    {
        model = new MVPModel(initialValue);
        presenter = new MVPPresenter(model, counterView);
    }

    void OnDestroy()
    {
        presenter?.Dispose();
    }
}
