using NLog;
using Study.Common.Interfaces;
using System;

namespace Study.Common.Helper
{
    public class NLogHelper : ILog
    {

        public Logger Logger { get; private set; }

        private NLogHelper()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }

        internal static class LazyHolder
        {
            static LazyHolder() { }
            internal static NLogHelper instance = new NLogHelper();
        }

        public static NLogHelper Instance()
        {
            return LazyHolder.instance;
        }

        public void WriteErrorLog(string erro, Exception ex)
        {
            Logger.Error(ex, erro);
        }

        public void WriteErrorLog(string erro)
        {
            Logger.Error(erro);
        }

        public void WriteInfoLog(string info)
        {
            Logger.Info(info);
        }
    }
}
