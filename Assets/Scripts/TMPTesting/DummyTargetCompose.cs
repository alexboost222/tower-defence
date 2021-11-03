using MVPPassiveView.Models.ProjectileTargets;
using MVPPassiveView.Presenters;
using MVPPassiveView.Views;
using UnityEngine;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(DummyTargetView))]
    public class DummyTargetCompose : MonoBehaviour, IProjectileTargetSource
    {
        private DummyTarget _model;
        private DummyTargetView _view;
        private DummyTargetPresenter _presenter;

        public IProjectileTarget Target => _model;

        public void Init(DummyTarget model)
        {
            _model = model;
            _presenter = new DummyTargetPresenter(_model, _view);
        }
        
        private void Awake() => _view = GetComponent<DummyTargetView>();
    }
}