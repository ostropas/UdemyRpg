using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour
{
    [SerializeField, HideInInspector] private NavMeshAgent _navMeshAgent = default;
    [SerializeField, HideInInspector] private Animator _animator = default;

    private Camera _mainCamera = default;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void OnValidate()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor(); 
        }
    }

    private void LateUpdate()
    {
        var localVelocity = transform.InverseTransformDirection(_navMeshAgent.velocity);
       _animator.SetFloat("forwardSpeed", localVelocity.z); 
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