﻿using System;
using System.Diagnostics;
using System.Reflection;
using EnsureThat.Extensions;

namespace EnsureThat
{
    public static partial class EnsureArg
    {
        private static class Types
        {
            internal static readonly Type IntType = typeof(int);

            internal static readonly Type ShortType = typeof(short);

            internal static readonly Type DecimalType = typeof(decimal);

            internal static readonly Type DoubleType = typeof(double);

            internal static readonly Type FloatType = typeof(float);

            internal static readonly Type BoolType = typeof(bool);

            internal static readonly Type DateTimeType = typeof(DateTime);

            internal static readonly Type StringType = typeof(string);
        }

        [DebuggerStepThrough]
        public static void IsInt(Type param, string paramName = Param.DefaultName) => IsOfType(param, Types.IntType, paramName);

        [DebuggerStepThrough]
        public static void IsShort(Type param, string paramName = Param.DefaultName) => IsOfType(param, Types.ShortType, paramName);

        [DebuggerStepThrough]
        public static void IsDecimal(Type param, string paramName = Param.DefaultName) => IsOfType(param, Types.DecimalType, paramName);

        [DebuggerStepThrough]
        public static void IsDouble(Type param, string paramName = Param.DefaultName) => IsOfType(param, Types.DoubleType, paramName);

        [DebuggerStepThrough]
        public static void IsFloat(Type param, string paramName = Param.DefaultName) => IsOfType(param, Types.FloatType, paramName);

        [DebuggerStepThrough]
        public static void IsBool(Type param, string paramName = Param.DefaultName) => IsOfType(param, Types.BoolType, paramName);

        [DebuggerStepThrough]
        public static void IsDateTime(Type param, string paramName = Param.DefaultName) => IsOfType(param, Types.DateTimeType, paramName);

        [DebuggerStepThrough]
        public static void IsString(Type param, string paramName = Param.DefaultName) => IsOfType(param, Types.StringType, paramName);

        [DebuggerStepThrough]
        public static void IsOfType(Type param, Type expectedType, string paramName = Param.DefaultName)
        {
            if (!Ensure.IsActive)
                return;

            if (param != expectedType)
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsNotOfType.Inject(param.FullName), paramName);
        }

        [DebuggerStepThrough]
        public static void IsClass(Type param, string paramName = Param.DefaultName)
        {
            if (!Ensure.IsActive)
                return;

            if (param == null)
                throw new ArgumentNullException(paramName, ExceptionMessages.EnsureExtensions_IsNotClass_WasNull);

            if (!param.GetTypeInfo().IsClass)
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsNotClass.Inject(param.FullName), paramName);
        }
    }
}