using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour
{
    [SerializeField, HideInInspector] private NavMeshAgent _navMeshAgent = default;

    private Camera _mainCamera = default;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void OnValidate()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor(); 
        }
    }

    private void MoveToCursor()
    {
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            _navMeshAgent.destination = hit.point;
        }
    }
}