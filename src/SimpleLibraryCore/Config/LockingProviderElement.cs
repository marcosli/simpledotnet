﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicLibrary.Configuration;

namespace SimpleLibrary.Config
{
    public class LockingProviderElement : ConfigElement
    {
        [ConfigElement("tableName", Default = "instance_state")]
        public string TableName { get; set; }

        [ConfigElement("typeColumn", Default = "type")]
        public string TypeColumn { get; set; }

        [ConfigElement("idColumn", Default = "id")]
        public string IdColumn { get; set; }

        [ConfigElement("semaphoreColumn", Default = "semaphore")]
        public string SemaphoreColumn { get; set; }

        [ConfigElement("dataColumn", Default = "data")]
        public string DataColumn { get; set; }

        [ConfigElement("defaultTimeout", Default = 30)]
        public int DefaultTimeout { get; set; }

    }
}