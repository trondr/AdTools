using System;
using Common.Logging;

namespace AdTools.Infrastructure
{
    public interface ILogFactory
    {
        ILog GetLogger(Type type);
    }
}