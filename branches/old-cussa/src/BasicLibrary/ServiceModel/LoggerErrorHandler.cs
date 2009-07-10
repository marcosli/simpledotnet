﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;
using log4net;
using System.Reflection;
using BasicLibrary.Logging;

namespace BasicLibrary.ServiceModel
{
    public class LoggerErrorHandler : IErrorHandler
    {
        protected static ILog Logger = MainLogger.Get(MethodInfo.GetCurrentMethod().DeclaringType);

        #region IErrorHandler Members

        public bool HandleError(Exception error)
        {
            Logger.Error(error.Message, error);
            return false;
        }

        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
        }

        #endregion
    }
}