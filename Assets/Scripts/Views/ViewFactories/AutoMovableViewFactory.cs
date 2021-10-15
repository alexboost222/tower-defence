using Models;
using UnityEngine;

namespace Views.ViewFactories
{
    public class AutoMovableViewFactory : MonoBehaviour
    {
        [SerializeField] private AutoMovableView template;

        private void Create()
        {
            AutoMovable autoMovable = new AutoMovable();
            AutoMovableView autoMovableView = Instantiate(template, autoMovable.Position, autoMovable.Rotation);
            autoMovableView.Init(autoMovable);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S)) Create();
        }
    }
}