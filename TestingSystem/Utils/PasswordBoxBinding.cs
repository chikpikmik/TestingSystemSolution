
using System.Windows;
using System.Windows.Controls;

namespace TestingSystem.Views
{
    public static class PasswordBoxBinding
    {
        private static bool _isUpdating;

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached(
                "Password",
                typeof(string),
                typeof(PasswordBoxBinding),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnPasswordPropertyChanged));

        public static string GetPassword(DependencyObject obj)
            => (string)obj.GetValue(PasswordProperty);

        public static void SetPassword(DependencyObject obj, string value)
            => obj.SetValue(PasswordProperty, value);

        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (_isUpdating) return;

            if (d is PasswordBox box)
            {
                box.PasswordChanged -= PasswordBox_PasswordChanged;

                if (box.Password != (string)e.NewValue)
                {
                    box.Password = (string)e.NewValue;
                }

                box.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox box)
            {
                _isUpdating = true;
                SetPassword(box, box.Password);
                _isUpdating = false;
            }
        }
    }
}
