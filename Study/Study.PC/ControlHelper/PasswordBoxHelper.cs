﻿using System.Windows;
using System.Windows.Controls;

namespace Study.PC.ControlHelper
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password",
            typeof(string), typeof(PasswordBoxHelper),
            new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            string password = (string)e.NewValue;
            if (passwordBox != null && passwordBox.Password != password)
                passwordBox.Password = password;
        }

        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }
    }
}
