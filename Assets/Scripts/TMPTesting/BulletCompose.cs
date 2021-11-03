using MVPPassiveView.Models.Projectiles;
using MVPPassiveView.Presenters;
using MVPPassiveView.Views;
using UnityEngine;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ProjectileView))]
    public class BulletCompose : MonoBehaviour
    {
        private ProjectileBase _model;
        private ProjectilePresenter _presenter;
        private ProjectileView _view;

        private bool _isInit;

        public void Init(ProjectileBase model)
        {
            if (_isInit) return;

            _model = model;
            _presenter = new ProjectilePresenter(_model, _view);

            _isInit = true;
        }
        
        private void Awake() => _view = GetComponent<ProjectileView>();
    }
}