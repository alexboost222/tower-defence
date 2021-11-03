using System;
using MVPPassiveView.Models.Guns;
using MVPPassiveView.Models.Projectiles;
using MVPPassiveView.Presenters;
using MVPPassiveView.Views;
using UnityEngine;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GunView))]
    public class MachineGunCompose : MonoBehaviour
    {
        private Gun _model;
        private GunPresenter _presenter;
        private GunView _view;

        private bool _isInit;

        public GunView View => _view;

        public void Init(Gun model, Action<ProjectileBase> shotFiredHandler)
        {
            if (_isInit) return;
            
            _model = model;
            _presenter = new GunPresenter(_model, _view, shotFiredHandler);

            _isInit = true;
        }
        
        private void Awake() => _view = GetComponent<GunView>();
    }
}