using System;

namespace Study.Common.Interfaces
{
    public interface ILog
    {
        void WriteInfoLog(string info);

        void WriteErrorLog(string erro, Exception ex);

        void WriteErrorLog(string erro);
    }
}
