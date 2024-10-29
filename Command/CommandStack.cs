using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CommandStack
{
    private Stack<ICommand> _commandHistory = new Stack<ICommand>();
    private Stack<ICommand> _redoStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
        _redoStack.Clear();
    }

    public void UndoLastCommand()
    {
        if (_commandHistory.Count <= 0)
        {
            return;
        }
        ICommand command = _commandHistory.Pop();
        command.Undo();
        _redoStack.Push(command);
    }
    public void RedoLastCommand()
    {
        if (_redoStack.Count <= 0) return;

        ICommand command = _redoStack.Pop();
        command.Execute();
        _commandHistory.Push(command);
    }
}
