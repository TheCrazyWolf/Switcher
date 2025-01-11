using Switcher.ModelViews;
using Wpf.Ui.Appearance;
using EditorViewModel = Switcher.ModelViews.Editor.EditorViewModel;

namespace Switcher.Windows.Editor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Editor
{
    public Editor(EditorViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        ApplicationThemeManager.Apply(this);
    }
}