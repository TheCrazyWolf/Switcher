using Wpf.Ui.Appearance;
using EditorViewModel = Switcher.ModelViews.Editor.EditorViewModel;

namespace Switcher.Windows.Editor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Editor
{
    public EditorViewModel ViewModel { get; }
    public Editor(EditorViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = ViewModel;
        ApplicationThemeManager.Apply(this);
    }
}