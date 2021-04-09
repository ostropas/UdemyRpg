using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour
{
    [SerializeField, HideInInspector] private NavMeshAgent _navMeshAgent = default;
    [SerializeField] private Transform _destinationTarget = default;

    private void OnValidate()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
       _navMeshAgent.destination = _destinationTarget.position; 
    }
}