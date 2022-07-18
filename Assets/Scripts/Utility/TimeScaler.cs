using System;
using Towers;
using UnityEngine;

namespace Utility
{
    public class TimeScaler : MonoBehaviour
    {
        [SerializeField] private float startTimeScale = 1;
        private float neededScale;

        private void Awake()
        {
            Time.timeScale = startTimeScale;
            neededScale = startTimeScale;
        }

        private void OnEnable()
        {
            TowerBuildPanel.OnShow += ActivateSlowMotion;
            TowerBuildPanel.OnHide += DeactivateSlowMotion;
        }

        private void OnDisable()
        {
            TowerBuildPanel.OnShow -= ActivateSlowMotion;
            TowerBuildPanel.OnHide -= DeactivateSlowMotion;
        }

        private void ActivateSlowMotion()
        {
            neededScale = startTimeScale / 10;
        }

        private void DeactivateSlowMotion()
        {
            neededScale = startTimeScale;
        }

        private void Update()
        {
            if (Time.timeScale != neededScale)
                Time.timeScale = Mathf.MoveTowards(Time.timeScale, neededScale, 4 * Time.deltaTime);
        }
    }
}