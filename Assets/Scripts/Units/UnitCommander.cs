using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    public class UnitCommander : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform _target;
        // Start is called before the first frame update
        void Start()
        {
            _agent.SetDestination(_target.position);
        }

    }
}