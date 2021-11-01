using Models;
using Models.Projectiles;
using Presenters;
using UnityEngine;
using Views;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ProjectileView))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float velocity;
        
        private ProjectileBase _model;
        private ProjectileView _view;
        private ProjectilePresenter _presenter;

        private bool _init;

        public void Init(IProjectileTarget target)
        {
            if (_init) return;
            
            _model = new LinearProjectile(target, velocity, _view.Position);
            _presenter = new ProjectilePresenter(_model, _view);
            
            _init = true;
        }
        
        private void Awake() => _view = GetComponent<ProjectileView>();
    }
}