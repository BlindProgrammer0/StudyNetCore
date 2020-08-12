using GalaSoft.MvvmLight;
using Study.Core.Interfaces;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Study.PC.ViewCenter
{
    public class BaseDialogCenter<TView, TViewModel> : IModuleDialog
          where TView : Window, new()
          where TViewModel : ViewModelBase, new()
    {
        protected TView View = new TView();
        protected TViewModel ViewModel = new TViewModel();

        /// <summary>
        /// 绑定默认ViewModel
        /// </summary>
        protected void BindDefaultViewModel()
        {
            View.DataContext = ViewModel;
        }

        /// <summary>
        /// 打开窗口
        /// </summary>
        /// <returns></returns>
        public virtual async Task<bool> ShowDialog()
        {
            this.SubscribeMessenger();
            this.SubscribeEvent();
            this.BindDefaultViewModel();
            var result = View.ShowDialog();
            return await Task.FromResult((bool)result);
        }

        public virtual void Close()
        {
        }

        /// <summary>
        /// 注册默认事件
        /// </summary>
        public void SubscribeEvent()
        {
            View.MouseDown += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    View.DragMove();
            };
        }

        public virtual void SubscribeMessenger()
        {
        }
    }
}
