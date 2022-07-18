using System;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class AliveUnits : MonoBehaviour
    {
        public static readonly List<EnemyUnit> units = new();

        private void OnEnable()
        {
            EnemyUnit.OnInitialized += AddUnit;
            EnemyUnit.OnDied += RemoveUnit;
        }

        private void OnDisable()
        {
            EnemyUnit.OnInitialized -= AddUnit;
            EnemyUnit.OnDied -= RemoveUnit;
        }

        void AddUnit(EnemyUnit unit)
        {
            units.Add(unit);
        }

        void RemoveUnit(EnemyUnit unit)
        {
            units.Remove(unit);
        }



    }
}