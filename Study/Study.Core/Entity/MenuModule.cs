namespace Study.Core.Entity
{
    using GalaSoft.MvvmLight;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;


    /// <summary>
    /// 菜单模块组
    /// </summary>
    public partial class MenuModuleGroup : ViewModelBase
    {
        public string MenuCode { get; set; }

        public string MenuName { get; set; }

        private ObservableCollection<MenuModule> modules = new ObservableCollection<MenuModule>();

        public ObservableCollection<MenuModule> Modules
        {
            get { return modules; }
            set { modules = value; RaisePropertyChanged(); }
        }
    }

    /// <summary>
    /// 菜单模块
    /// </summary>
    public class MenuModule : ViewModelBase
    {
        public string Name { get; set; }

        private int _value;

        /// <summary>
        /// 权限值
        /// </summary>
        public int Value
        {
            get { return _value; }
            set { _value = value; RaisePropertyChanged(); }
        }

        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; RaisePropertyChanged(); }
        }
    }
}
