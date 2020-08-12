using Autofac;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Study.Common.Interfaces;
using Study.Core.Common.Contract;
using Study.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Study.ViewModel
{
    /// <summary>
    /// 登录模块
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        private readonly IConsumptionService service;
        public LoginViewModel()
        {
            NetCoreProvider.Get(out service);
            LoginCommand = new RelayCommand(Login);
        }

        #region Property
        private string userName;
        private string passWord;
        private string report;
        private string isCancel;

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(); }
        }

        public string Report
        {
            get { return report; }
            set { report = value; RaisePropertyChanged(); }
        }

        public string IsCancel
        {
            get { return isCancel; }
            set { isCancel = value; RaisePropertyChanged(); }
        }
        #endregion

        #region Command

        public RelayCommand LoginCommand { get; private set; }

        /// <summary>
        /// 登录系统
        /// </summary>
        private async void Login()
        {
            try
            {
                if (DialogIsOpen) return;
                if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(PassWord))
                {
                    SnackBar("请输入用户名密码!");
                    return;
                }
                DialogIsOpen = true;
                await Task.Delay(300);
                var r = await service.LoginAsync(UserName, PassWord);
                if (r == null || !r.success)
                {
                    SnackBar(r == null ? "远程服务器无法连接!" : r.message);
                    return;
                }
                var authResult = await service.GetAuthListAsync();
                if (authResult == null || !authResult.success)
                {
                    SnackBar("获取模块清单异常!");
                    return;
                }
                #region 关联用户信息/缓存

                Contract.Account = r.dynamicObj.User.Account;
                Contract.UserName = r.dynamicObj.User.UserName;
                Contract.IsAdmin = r.dynamicObj.User.FlagAdmin == 1;
                Contract.Menus = r.dynamicObj.Menus; //用户包含的权限信息
                Contract.AuthItems = authResult.dynamicObj;

                #endregion

                //这行代码会发射到首页,Center中会定义所有的Messenger
                Messenger.Default.Send(true, "NavigationPage");
            }
            catch (Exception ex)
            {
                SnackBar(ex.Message);

                NetCoreProvider.Instance.Resolve<ILog>().WriteErrorLog(ex.Message);
            }
            finally
            {
                DialogIsOpen = false;
            }
        }

        #endregion

        public override void Exit()
        {
            Messenger.Default.Send(false, "Exit");
        }
    }
}
