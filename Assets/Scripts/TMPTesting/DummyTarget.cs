using MVPPassiveView.Models.ProjectileTargets;
using MVPPassiveView.Presenters;
using MVPPassiveView.Views;
using UnityEngine;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(DummyTargetView))]
    public class DummyTarget : MonoBehaviour, IProjectileTargetSource
    {
        private MVPPassiveView.Models.ProjectileTargets.DummyTarget _model;
        private DummyTargetView _view;
        private DummyTargetPresenter _presenter;

        public IProjectileTarget Target => _model;

        private void Awake()
        {
            _view = GetComponent<DummyTargetView>();
            _model = new MVPPassiveView.Models.ProjectileTargets.DummyTarget(transform.position);
            _presenter = new DummyTargetPresenter(_model, _view);
        }
    }
}