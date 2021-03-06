﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SQLToCSharpNamespace
{
    public class SQLToCSharp
    {
        public static SqlDbType SqlTypeToSqlDBType(string sqlType)
        {
            SqlDbType dbType = SqlDbType.Variant;//默认为Object
            switch (sqlType)
            {
                case "int":
                    dbType = SqlDbType.Int;
                    break;
                case "varchar":
                    dbType = SqlDbType.VarChar;
                    break;
                case "bit":
                    dbType = SqlDbType.Bit;
                    break;
                case "datetime":
                    dbType = SqlDbType.DateTime;
                    break;
                case "decimal":
                    dbType = SqlDbType.Decimal;
                    break;
                case "float":
                    dbType = SqlDbType.Float;
                    break;
                case "image":
                    dbType = SqlDbType.Image;
                    break;
                case "money":
                    dbType = SqlDbType.Money;
                    break;
                case "ntext":
                    dbType = SqlDbType.NText;
                    break;
                case "nvarchar":
                    dbType = SqlDbType.NVarChar;
                    break;
                case "smalldatetime":
                    dbType = SqlDbType.SmallDateTime;
                    break;
                case "smallint":
                    dbType = SqlDbType.SmallInt;
                    break;
                case "text":
                    dbType = SqlDbType.Text;
                    break;
                case "bigint":
                    dbType = SqlDbType.BigInt;
                    break;
                case "binary":
                    dbType = SqlDbType.Binary;
                    break;
                case "char":
                    dbType = SqlDbType.Char;
                    break;
                case "nchar":
                    dbType = SqlDbType.NChar;
                    break;
                case "numeric":
                    dbType = SqlDbType.Decimal;
                    break;
                case "real":
                    dbType = SqlDbType.Real;
                    break;
                case "smallmoney":
                    dbType = SqlDbType.SmallMoney;
                    break;
                case "sql_variant":
                    dbType = SqlDbType.Variant;
                    break;
                case "timestamp":
                    dbType = SqlDbType.Timestamp;
                    break;
                case "tinyint":
                    dbType = SqlDbType.TinyInt;
                    break;
                case "uniqueidentifier":
                    dbType = SqlDbType.UniqueIdentifier;
                    break;
                case "varbinary":
                    dbType = SqlDbType.VarBinary;
                    break;
                case "xml":
                    dbType = SqlDbType.Xml;
                    break;
                case "Name":
                    dbType = SqlDbType.VarChar;
                    break;
            }
            return dbType;
        }

        public static Type sqlDBTypeToCSharpType(SqlDbType sqlDBType)
        {
            switch (sqlDBType)
            {
                case SqlDbType.BigInt:
                    return typeof(Int64);
                case SqlDbType.Binary:
                    return typeof(Object);
                case SqlDbType.Bit:
                    return typeof(Boolean);
                case SqlDbType.Char:
                    return typeof(String);
                case SqlDbType.DateTime:
                    return typeof(DateTime);
                case SqlDbType.Decimal:
                    return typeof(Decimal);
                case SqlDbType.Float:
                    return typeof(Double);
                case SqlDbType.Image:
                    return typeof(Object);
                case SqlDbType.Int:
                    return typeof(Int32);
                case SqlDbType.Money:
                    return typeof(Decimal);
                case SqlDbType.NChar:
                    return typeof(String);
                case SqlDbType.NText:
                    return typeof(String);
                case SqlDbType.NVarChar:
                    return typeof(String);
                case SqlDbType.Real:
                    return typeof(Single);
                case SqlDbType.SmallDateTime:
                    return typeof(DateTime);
                case SqlDbType.SmallInt:
                    return typeof(Int16);
                case SqlDbType.SmallMoney:
                    return typeof(Decimal);
                case SqlDbType.Text:
                    return typeof(String);
                case SqlDbType.Timestamp:
                    return typeof(Object);
                case SqlDbType.TinyInt:
                    return typeof(Byte);
                case SqlDbType.Udt://自定义的数据类型
                    return typeof(Object);
                case SqlDbType.UniqueIdentifier:
                    return typeof(Object);
                case SqlDbType.VarBinary:
                    return typeof(Object);
                case SqlDbType.VarChar:
                    return typeof(String);
                case SqlDbType.Variant:
                    return typeof(Object);
                case SqlDbType.Xml:
                    return typeof(Object);
                default:
                    return null;
            }
        }

        public static SqlDbType CSharpTypeTosqlDBType(Type type)
        {
            if (type.Name.Equals(typeof(Int64).Name))
                return SqlDbType.BigInt;
            else if (type.Name.Equals(typeof(Object).Name))
                return SqlDbType.Binary;
            else if (type.Name.Equals(typeof(Boolean).Name))
                return SqlDbType.Bit;
            else if (type.Name.Equals(typeof(String).Name))
                return SqlDbType.Char;
            else if (type.Name.Equals(typeof(DateTime).Name))
                return SqlDbType.DateTime;
            else if (type.Name.Equals(typeof(Decimal).Name))
                return SqlDbType.Decimal;
            else if (type.Name.Equals(typeof(Double).Name))
                return SqlDbType.Float;
            else if (type.Name.Equals(typeof(Object).Name))
                return SqlDbType.Image;
            else if (type.Name.Equals(typeof(Int32).Name))
                return SqlDbType.Int;
            else if (type.Name.Equals(typeof(Decimal).Name))
                return SqlDbType.Money;
            else if (type.Name.Equals(typeof(String).Name))
                return SqlDbType.NChar;
            else if (type.Name.Equals(typeof(String).Name))
                return SqlDbType.NText;
            else if (type.Name.Equals(typeof(String).Name))
                return SqlDbType.NVarChar;
            else if (type.Name.Equals(typeof(Single).Name))
                return SqlDbType.Real;
            else if (type.Name.Equals(typeof(DateTime).Name))
                return SqlDbType.SmallDateTime;
            else if (type.Name.Equals(typeof(Int16).Name))
                return SqlDbType.SmallInt;
            else if (type.Name.Equals(typeof(Decimal).Name))
                return SqlDbType.SmallMoney;
            else if (type.Name.Equals(typeof(String).Name))
                return SqlDbType.Text;
            else if (type.Name.Equals(typeof(Object).Name))
                return SqlDbType.Timestamp;
            else if (type.Name.Equals(typeof(Byte).Name))
                return SqlDbType.TinyInt;
            else if (type.Name.Equals(typeof(Object).Name))
                return SqlDbType.Udt;
            else if (type.Name.Equals(typeof(Object).Name))
                return SqlDbType.UniqueIdentifier;
            else if (type.Name.Equals(typeof(Object).Name))
                return SqlDbType.VarBinary;
            else if (type.Name.Equals(typeof(String).Name))
                return SqlDbType.VarChar;
            else if (type.Name.Equals(typeof(Object).Name))
                return SqlDbType.Variant;
            else if (type.Name.Equals(typeof(Object).Name))
                return SqlDbType.Xml;
            else
                return SqlDbType.Int;
        }

        public static Type SqlTypeToCSharpType(string sqlType)
        {
            SqlDbType sqlDbType = SqlTypeToSqlDBType(sqlType);
            Type type = sqlDBTypeToCSharpType(sqlDbType);
            return type;
        }
    }
}