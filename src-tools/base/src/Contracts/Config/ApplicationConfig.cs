﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Sample.Project.Config
{
    [XmlRoot("application")]
    public class ApplicationConfig
    {
        public class ServiceConfig
        {
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("display-name")]
            public string DisplayName { get; set; }
        }

        [XmlElement("service")]
        public ServiceConfig Service { get; set; }

        [XmlElement("ado-provider")]
        public string ADOProvider { get; set; }
    }
}