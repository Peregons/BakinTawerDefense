using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private float _shotRadius;
        [SerializeField] private float _reloadTime;
        [SerializeField] private float _damage;

        protected EnemyUnit _targetUnit;
        private float _currentReloadTime;
        private Vector2 _position;

        protected virtual void Awake()
        {
            _position = new Vector2(transform.position.x, transform.position.z);
        }

        protected virtual void Update()
        {
            _currentReloadTime -= Time.deltaTime;
            _targetUnit = null;

            if (AliveUnits.units.Count > 0)
            {
                FindClosestUnit();

                if (_targetUnit && _currentReloadTime <= 0)
                    Shot();
            }
        }

        protected virtual void Shot()
        {
            _currentReloadTime = _reloadTime;
            _targetUnit.ApplyDamage(_damage);
        }



        private void FindClosestUnit()
        {
            var closestDistance = _shotRadius;
            foreach (var unit in AliveUnits.units)
            {
                Vector3 unitPosition = unit.transform.position;
                var distance = Vector2.Distance(new Vector2(unitPosition.x, unitPosition.z), _position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    _targetUnit = unit;
                }
            }
        }

        protected void RotateToTarget()
        {
            Vector3 direction = _targetUnit.transform.position  - transform.position;
            transform.forward = new Vector3(direction.x, 0, direction.z);
        }
    }
}