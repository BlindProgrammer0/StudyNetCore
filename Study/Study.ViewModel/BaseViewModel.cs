using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Study.ViewModel
{
    /// <summary>
    /// MVVM基类
    /// </summary>
    public class BaseViewModel : ViewModelBase
    {
        public BaseViewModel()
        {
            ExitCommand = new RelayCommand(Exit);
        }
        public RelayCommand ExitCommand { get; private set; }

        /// <summary>
        /// 传递True代表需要确认用户是否关闭,你可以选择传递false强制关闭
        /// </summary>
        public virtual void Exit()
        {
            Messenger.Default.Send(true, "Exit");
        }


        private bool isOpen;

        /// <summary>
        /// 窗口是否显示
        /// </summary>
        public bool DialogIsOpen
        {
            get { return isOpen; }
            set { isOpen = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 通知异常
        /// </summary>
        /// <param name="msg"></param>
        public void SnackBar(string msg)
        {
            Messenger.Default.Send(msg, "Snackbar");
        }
    }
}
