using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(Animator))]
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] float _spawnFrequency = 1f;
        [SerializeField] float _unitCount = 1f;
        [SerializeField] EnemyUnit _unitTemplate;
        [SerializeField] Transform[] _unitTargets;
        [SerializeField] GameObject _unitVisual;

        float _unitsLeft;

        private static readonly int Frequency = Animator.StringToHash("frequency");

        // Start is called before the first frame update
        private void Awake()
        {
            _unitsLeft = _unitCount;
            var animator = GetComponent<Animator>();
            animator.SetFloat(Frequency, _spawnFrequency);
            _unitTemplate.gameObject.SetActive(false);
        }

        public void SpawnUnit()
        {
            if (_unitsLeft <= 0)
                return;

            _unitsLeft--;
            var unit = Instantiate(_unitTemplate, _unitTemplate.transform.parent);
            unit.Initialize(_unitTargets[Random.Range(0, _unitTargets.Length)]);

            if (_unitsLeft <= 0)
                _unitVisual.SetActive(false);
        }
    }
}