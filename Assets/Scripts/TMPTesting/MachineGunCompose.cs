using System;
using Models.Guns;
using Models.Projectiles;
using Presenters;
using UnityEngine;
using Views;

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