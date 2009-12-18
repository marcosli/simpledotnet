﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Migrator.Framework;

namespace Schema.Migrator
{
    public abstract class InsideTableAction : IAction
    {
        public TableAction Table { get; set; }
        public abstract void Execute(ITransformationProvider migration);

        public InsideTableAction(TableAction table)
        {
            this.Table = table;
        }
    }

}
