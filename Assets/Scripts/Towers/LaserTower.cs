using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Towers
{
    public class LaserTower : Tower
    {
        [SerializeField] private LineRenderer _laserEffect;
        [SerializeField] private Transform _laserOrigin;

        protected override void Update()
        {
            base.Update();

            _laserEffect.gameObject.SetActive(_targetUnit);

            if (_targetUnit)
            {
                RotateToTarget();
                UpdateLaserEffect();
            }
        }

        private void UpdateLaserEffect()
        {
            _laserEffect.SetPosition(0, _laserOrigin.position);
            _laserEffect.SetPosition(1, _targetUnit.GetBodyCenter());
            _laserEffect.startColor = Random.ColorHSV();
            _laserEffect.endColor = Random.ColorHSV();
            _laserEffect.startWidth = Random.Range(0.08f, 0.12f);
            _laserEffect.endWidth = Random.Range(0.12f, 0.16f);
        }
    }
}