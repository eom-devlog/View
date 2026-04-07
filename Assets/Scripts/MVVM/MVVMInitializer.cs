using UnityEngine;

public class MVVMInitializer : MonoBehaviour
{
    [SerializeField] private MVVMView counterView;
    [SerializeField] private int initialValue = 0;

    private MVVMModel model;
    private MVVMViewModel viewModel;

    void Start()
    {
        model = new MVVMModel(initialValue);
        viewModel = new MVVMViewModel(model);
        counterView.Bind(viewModel);
    }

    void OnDestroy()
    {
        counterView?.Unbind();
    }
}
