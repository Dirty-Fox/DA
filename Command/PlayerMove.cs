using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Button up;
    [SerializeField] private Button down;
    [SerializeField] private Button left;
    [SerializeField] private Button right;

    [SerializeField] private Button _undo;
    [SerializeField] private Button _redo;

    private CommandStack _commandStack = new CommandStack();

    private void Start()
    {
        up.onClick.AddListener(() => Move(Vector3.forward));
        down.onClick.AddListener(() => Move(Vector3.back));
        left.onClick.AddListener(() => Move(Vector3.left));
        right.onClick.AddListener(() => Move(Vector3.right));
        _undo.onClick.AddListener(_commandStack.UndoLastCommand);
        _redo.onClick.AddListener(_commandStack.RedoLastCommand);
    }

    private void Move(Vector3 direction)
    {
        MoveCommand moveCommand = new MoveCommand(transform, direction);
        _commandStack.ExecuteCommand(moveCommand);
    }
}
