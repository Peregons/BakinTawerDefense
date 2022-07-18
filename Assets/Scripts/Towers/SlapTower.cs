using UnityEngine;

namespace Towers
{
    public class SlapTower : Tower
    {
        private bool _isHitting;

        private Animator _animator;

        private static readonly int Hit = Animator.StringToHash("Hit");

        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        protected override void Shot()
        {
            base.Shot();
            RotateToTarget();
            _isHitting = true;
            _animator.SetTrigger(Hit);
        }

        // Update is called once per frame
        void Update()
        {
            base.Update();

            if (_targetUnit && !_isHitting)
                RotateToTarget();


        }

        public void SetNotHitting()
        {
            _isHitting = false;
        }
    }
}