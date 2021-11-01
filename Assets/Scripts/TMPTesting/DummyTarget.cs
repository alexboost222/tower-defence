using Models;
using Presenters;
using UnityEngine;
using Views;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(DummyTargetView))]
    public class DummyTarget : MonoBehaviour
    {
        private Models.DummyTarget _model;
        private DummyTargetView _view;
        private DummyTargetPresenter _presenter;

        public IProjectileTarget Target => _model;

        private void Awake()
        {
            _view = GetComponent<DummyTargetView>();
            _model = new Models.DummyTarget(_view.Position);
            _presenter = new DummyTargetPresenter(_model, _view);
        }
    }
}