using System.Windows;
using Switcher.Interfaces;

namespace Switcher.Implementations;

public class WindowService : IWindowService
{
    private readonly Window _window;

    public WindowService(Window window)
    {
        _window = window;
    }

    public void CloseWindow()
    {
        _window.Close();
    }
}