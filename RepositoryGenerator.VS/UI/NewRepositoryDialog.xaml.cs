using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.RepositoryGenerator.Abstractions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VSSettings = Microsoft.VisualStudio.RepositoryGenerator.Properties.Settings;

namespace Microsoft.VisualStudio.RepositoryGenerator.UI
{
    /// <summary>
    /// Interaction logic for NewRepositoryDialog.xaml
    /// </summary>
    public partial class NewRepositoryDialog : DialogWindow
    {
        public NewRepositoryDialog()
        {
            var viewModel = new RepositoryGeneratorParameters();
            InitializeComponent();
            PreviewKeyDown += OnPreviewKeyDown;
            MainGrid.DataContext = viewModel;
        }

        public NewRepositoryDialog(RepositoryGeneratorParameters viewModel)
        {
            InitializeComponent();
            PreviewKeyDown += OnPreviewKeyDown;
            viewModel.RepositoryName = VSSettings.Default.RepositoryName;
            viewModel.ProjectName = VSSettings.Default.ProjectName;
            viewModel.SolutionName = VSSettings.Default.SolutionName;
            viewModel.RootNamespace = VSSettings.Default.RootNamespace;
            viewModel.Description = VSSettings.Default.Description;
            viewModel.Output = VSSettings.Default.Output;
            viewModel.TargetFramework = VSSettings.Default.TargetFramework;
            viewModel.SdkXmlLocation = VSSettings.Default.SdkXmlElementLocation;
            viewModel.RepositoryStyle = VSSettings.Default.RepositoryStyle;
            MainGrid.DataContext = viewModel;
            RepositoryNameTextBox.Focus();
        }


        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                CloseSad();
            }
        }

        private void CloseHappy()
        {
            VSSettings.Default.ProjectName = ProjectNameTextBox.Text;
            VSSettings.Default.RepositoryName = RepositoryNameTextBox.Text;
            VSSettings.Default.SolutionName = SolutionNameTextBox.Text;
            VSSettings.Default.RootNamespace = RootNamespaceTextBox.Text;
            VSSettings.Default.Description = DescriptionTextBox.Text;
            VSSettings.Default.Output = OutputPathTextBox.Text;
            VSSettings.Default.RepositoryStyle = (RepositoryStyle)RepositoryStyleComboBox.SelectedItem;
            VSSettings.Default.SdkXmlElementLocation = (SdkXmlElementLocation)SdkXmlLocationComboBox.SelectedItem;
            VSSettings.Default.TargetFramework = (TargetFramework)TargetFrameworkComboBox.SelectedItem;

            DialogResult = true;
            Close();
        }

        private void CloseSad()
        {
            DialogResult = false;
            Close();
        }

        private void OnOKButtonClick(object sender, RoutedEventArgs e)
        {
            CloseHappy();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            CloseSad();
        }

        private void OnBrowseButtonClick(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog())
            {
                fbd.Description = "Choose a directory for the repository folder.";
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                fbd.ShowNewFolderButton = true;

                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    OutputPathTextBox.SetValue(TextBox.TextProperty, fbd.SelectedPath);
                }
            }
        }

        private void OnRepositoryNameTextChanged(object sender, TextChangedEventArgs e)
        {
            if (AutoFillCheckBox.IsChecked != true) return;

            ProjectNameTextBox.Text = RepositoryNameTextBox.Text;
            SolutionNameTextBox.Text = RepositoryNameTextBox.Text;
            RootNamespaceTextBox.Text = RepositoryNameTextBox.Text;
            DescriptionTextBox.Text = RepositoryNameTextBox.Text;
        }
    }
}
