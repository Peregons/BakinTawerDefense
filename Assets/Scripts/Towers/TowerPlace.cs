using System;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Collider))]
    public class TowerPlace : MonoBehaviour
    {
        public static event Action<TowerPlace> OnClick;
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            transform.forward = Vector3.back;
        }

        private void OnMouseDown()
        {
            OnClick?.Invoke(this);
        }

        public void SetColliderActive(bool value)
        {
            _collider.enabled = value;
        }
    }
}