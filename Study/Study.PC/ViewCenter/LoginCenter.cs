using GalaSoft.MvvmLight.Messaging;
using Study.PC.View;
using Study.ViewModel;
using Study.ViewModel.Common;
using System;

namespace Study.PC.ViewCenter
{
    /// <summary>
    /// 登录控制类
    /// </summary>
    public class LoginCenter : BaseDialogCenter<LoginView, LoginViewModel>
    {
        public override void SubscribeMessenger()
        {
            Messenger.Default.Register<string>(View, "Snackbar", arg =>
            {
                //var messageQueue = View.SnackbarThree.MessageQueue;
                //messageQueue.Enqueue(arg);
            });
            Messenger.Default.Register<bool>(View, "NavigationPage", async arg =>
            {
                //MainCenter mainView = new MainCenter();
                //View.Close();
                //await mainView.ShowDialog();
                new MainWindow().Show();
            });
            Messenger.Default.Register<bool>(View, "Exit", async r =>
            {
                if (r)
                    if (!await Msg.Question("确认退出系统?")) return;
                Environment.Exit(0);
            });
        }
    }
}
