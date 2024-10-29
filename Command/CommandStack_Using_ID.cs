using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CommandStack
{
    private List<ICommand> _commandHistory = new List<ICommand>();
    private int _currentIndex = -1;

    public void ExecuteCommand(ICommand command)
    {
        // If we're in the middle of the history, remove the forward history
        if (_currentIndex < _commandHistory.Count - 1)
        {
            _commandHistory.RemoveRange(_currentIndex + 1, _commandHistory.Count - _currentIndex - 1);
        }

        command.Execute();
        _commandHistory.Add(command);
        _currentIndex++;
    }

    public void UndoLastCommand()
    {
        if (_currentIndex < 0) return;

        _commandHistory[_currentIndex].Undo();
        _currentIndex--;
    }

    public void RedoLastCommand()
    {
        if (_currentIndex >= _commandHistory.Count - 1) return;

        _currentIndex++;
        _commandHistory[_currentIndex].Execute();
    }
}
