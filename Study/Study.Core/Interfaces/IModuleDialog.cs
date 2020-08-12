using System.Threading.Tasks;

namespace Study.Core.Interfaces
{
    /// <summary>
    /// 弹出式窗口接口
    /// </summary>
    public interface IModuleDialog
    {
        /// <summary>
        /// 弹出窗口
        /// </summary>
        Task<bool> ShowDialog();

        /// <summary>
        /// 关闭窗口
        /// </summary>
        void Close();

        /// <summary>
        /// 注册模块事件
        /// </summary>
        void SubscribeEvent();

        /// <summary>
        /// 注册模块消息
        /// </summary>
        void SubscribeMessenger();

    }
}
