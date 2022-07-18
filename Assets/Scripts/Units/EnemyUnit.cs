using System;
using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class EnemyUnit : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Rigidbody _body;
        [SerializeField] private float _maxHp;
        [SerializeField] private Transform _bodyCenter;
        public static event Action<EnemyUnit> OnInitialized;
        public static event Action<EnemyUnit> OnDied;

        private bool _isActive;
        private float _hp;

        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            if (_isActive && _agent.remainingDistance - _agent.stoppingDistance <= 0)
                FinishPath();
        }

        void FinishPath()
        {
            _isActive = false;
            _agent.enabled = false;
            _body.isKinematic = false;
            OnDied?.Invoke(this);
            Destroy(gameObject, 2f);
        }

        public void Initialize(Transform unitTarget)
        {
            _isActive = true;
            _agent.enabled = true;
            _body.isKinematic = true;
            _hp = _maxHp;
            gameObject.SetActive(true);
            _agent.SetDestination(unitTarget.position);
            OnInitialized?.Invoke(this);

        }

        public void ApplyDamage(float damage)
        {
            _hp -= damage;

            if (_hp <= 0)
                Die();
        }

        private void Die()
        {
            _isActive = false;
            OnDied?.Invoke(this);
            Destroy(gameObject, 0.2f);
        }

        public Vector3 GetBodyCenter()
        {
            return _bodyCenter.position;
        }
    }
}