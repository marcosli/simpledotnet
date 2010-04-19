﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Config;
using System.Linq.Expressions;
using Simple.Expressions.Editable;
using Simple.Services;
using Simple.Expressions;

namespace Simple.Entities
{
    internal static class ExpressionExtensions
    {
        public static T Funcletize<T>(this T expr)
            where T : Expression
        {
            return (T)Funcletizer.PartialEval(expr);
        }
    }

}
