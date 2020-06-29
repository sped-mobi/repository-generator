namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Defines the <see cref="ObservableObject" />.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Defines the PropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The NotifyPropertyChanged.
        /// </summary>
        /// <param name="propertyName">The propertyName<see cref="string"/>.</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged == null)
                return;
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The SetProperty.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="field">The field<see cref="T"/>.</param>
        /// <param name="newValue">The newValue<see cref="T"/>.</param>
        /// <param name="propertyName">The propertyName<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
                return false;
            field = newValue;
            NotifyPropertyChanged(propertyName);
            return true;
        }
    }
}
