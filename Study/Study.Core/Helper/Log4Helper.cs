using log4net;
using log4net.Config;
using System;
using System.Reflection;

namespace Study.Common.Helper
{
    public class Log4Helper : Study.Common.Interfaces.ILog
    {
        ///// <summary>
        ///// 只读实体对象info信息
        ///// </summary>
        public ILog Loginfo { get; private set; }

        /// <summary>
        /// 只读实体对象error信息
        /// </summary>
        public ILog Logerror { get; private set; }

        #region 单例模式
        private static class LazyHolder
        {
            static LazyHolder() { }
            internal static Log4Helper instance = new Log4Helper();
        }
        private Log4Helper()
        {
            var assembly = Assembly.GetCallingAssembly();
            var repository = LogManager.GetRepository(assembly);
            XmlConfigurator.ConfigureAndWatch(repository, new System.IO.FileInfo("log4net.config"));
            //var logs = LogManager.GetCurrentLoggers(repository.Name);
            Loginfo = LogManager.GetLogger(assembly,"logInfo");
            Logerror = LogManager.GetLogger(assembly, "logError");          
        }
        public static Log4Helper Instance()
        {
            return LazyHolder.instance;

        }
        #endregion

        #region 废弃
        ///// <summary>
        ///// 只读实体对象info信息
        ///// </summary>
        //public readonly ILog Loginfo = log4net.LogManager.GetLogger("logInfo");
        ///// <summary>
        ///// 只读实体对象error信息
        ///// </summary>
        //public readonly ILog Logerror = log4net.LogManager.GetLogger("logError");
        ///// <summary>
        ///// 只读实体对象info信息
        ///// </summary>
        //public readonly ILog Loginfo2 = log4net.LogManager.GetLogger("logInfo2");

        ///// <summary>
        ///// 只读实体Logs信息
        ///// </summary>
        //public log4net.ILog[] Logs => LogManager.GetCurrentLoggers();
        #endregion


        /// <summary>    
        /// 写入info信息
        /// </summary>
        /// <param name="info">自定义日志内容说明</param>
        public void WriteInfoLog(string info)
        {
            try
            {
                if (Loginfo.IsInfoEnabled)
                {
                    Loginfo.Info(info);
                }
            }
            catch { }
        }

        /// <summary>
        /// 写入异常信息附带Exception
        /// </summary>
        /// <param name="info">自定义日志内容说明</param>
        /// <param name="ex">异常信息</param>
        public void WriteErrorLog(string erro, Exception ex)
        {
            try
            {
                if (Logerror.IsErrorEnabled)
                {
                    Logerror.Error(erro, ex);
                }
            }
            catch { }
        }

        /// <summary>
        /// 写入异常信息
        /// </summary>
        /// <param name="info">自定义日志内容说明</param>
        /// <param name="ex">异常信息</param>
        public void WriteErrorLog(string erro)
        {
            try
            {
                if (Logerror.IsErrorEnabled)
                {
                    Logerror.Error(erro);
                }
            }
            catch { }
        }

        ///// <summary>
        /////  写入info信息
        ///// </summary>
        ///// <param name="info">自定义日志内容说明</param>
        //public void WriteInfoLog2(string info, string htmlColor)
        //{
        //    try
        //    {
        //        if (Loginfo2.IsInfoEnabled)
        //        {
        //            string text = $"<span style='color:{htmlColor}'>" + info + "<span>";

        //            Loginfo2.Info(text);
        //        }
        //    }
        //    catch { }
        //}


    }
}
