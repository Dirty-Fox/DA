using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Transform _transform;
    private Vector3 _movement;
    private Vector3 _previousPosition;

    public MoveCommand(Transform transform, Vector3 movement)
    {
        _transform = transform;
        _movement = movement;
    }

    public void Execute()
    {
        _previousPosition = _transform.position;
        _transform.position += _movement;
    }

    public void Undo()
    {
        _transform.position = _previousPosition;
    }
}
