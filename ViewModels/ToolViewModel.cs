using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CAD_Application.ViewModels
{
    /// <summary>
    /// ViewModel for managing tool-specific state and operations.
    /// Represents the currently active tool (Line, Circle, Offset, etc.).
    /// </summary>
    public class ToolViewModel : ViewModelBase
    {
        private string _toolName;
        private string _statusMessage;
        private bool _isActive;

        public string ToolName
        {
            get => _toolName;
            set => SetProperty(ref _toolName, value);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        public ToolViewModel(string toolName)
        {
            ToolName = toolName;
            StatusMessage = $"Tool: {toolName}";
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
            StatusMessage = $"{ToolName} activated";
        }

        public void Deactivate()
        {
            IsActive = false;
            StatusMessage = $"{ToolName} deactivated";
        }

        public void UpdateStatus(string message)
        {
            StatusMessage = message;
        }
    }
}
