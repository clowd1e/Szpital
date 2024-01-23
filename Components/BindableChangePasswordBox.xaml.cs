using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szpital.Components
{
    /// <summary>
    /// Interaction logic for BindableChangePasswordBox.xaml
    /// </summary>
    public partial class BindableChangePasswordBox : UserControl
    {
        private bool isPasswordChanging;

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }


        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindableChangePasswordBox), new PropertyMetadata(string.Empty, PasswordPropertyChanged));

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindableChangePasswordBox changePasswordBox)
            {
                changePasswordBox.UpdatePassword();
            }
        }

        public BindableChangePasswordBox()
        {
            InitializeComponent();
        }

        private void changePasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            isPasswordChanging = true;
            Password = changePasswordBox.Password;
            isPasswordChanging = false;
        }
        private void UpdatePassword()
        {
            if (!isPasswordChanging)
            {
                changePasswordBox.Password = Password;
            }
        }
    }
}
