using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    #region PRIVATE VARIABLE
    [SerializeField] private Transform[] _wayPointList;

    private NavMeshAgent _navMeshAgent;
    private Transform _currentTarget;
    private CapsuleCollider _capsuleCollider;

    public Transform Target
    {
        get { return _currentTarget; }
    }
    #endregion

    #region BUILTIN METHOD
    void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    
    void Update()
    {
        Locomotion();
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
    }
    #endregion

    #region CUSTOM METHOD
    private void Locomotion()
    {
        // si pas de destination ou destination atteinte
        if (_currentTarget == null
            || Vector2.Distance(
                new Vector2(_currentTarget.position.x, _currentTarget.position.z),
                new Vector2(transform.position.x, transform.position.z)) <= 0.5f
            || (_currentTarget.position.x == transform.position.x && _currentTarget.position.z == transform.position.z))
        {
            // Choix de la prochaine destination aléatoirement
            ChooseRandomTarget();
        }
        if (_navMeshAgent)
        {
            // Assignation de la destination
            _navMeshAgent.destination = _currentTarget.position;
        }

    }
    private void ChooseRandomTarget()
    {
        if (_wayPointList!= null && _wayPointList.Length > 1)
        {
            Transform futurTarget = _wayPointList[Random.Range(0, _wayPointList.Length)];
            if (_currentTarget != null)
            {
                // Recherche aléatoirement une prochine destination de ronde qui n'est pas celle où l'on est déja
                while (futurTarget == _currentTarget)
                {
                    futurTarget = _wayPointList[Random.Range(0, _wayPointList.Length)];
                }
            }
            _currentTarget = futurTarget;
        }
    }
    #endregion
}
