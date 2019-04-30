using System;

namespace Algorithm.Helper
{
    public static class ObjectHelper
    {
            public static int GetInt(this object obj)
            {
                int result = 0;
                try
                {
                    if (obj != null)
                        result = Convert.ToInt32(obj);
                }
                catch (Exception)
                {

                }
                return result;
            }
            public static long GetLong(this object obj)
            {
                long result = 0;
                try
                {

                    if (obj != null)
                        result = Convert.ToInt64(obj);
                }
                catch (Exception)
                {
                }
                return result;
            }
            public static bool GetBoolean(this object obj)
            {
                bool boolval = false;
                try
                {
                    switch (Type.GetTypeCode(obj.GetType()))
                    {
                        case TypeCode.Byte:
                        case TypeCode.Decimal:
                        case TypeCode.Double:
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.SByte:
                        case TypeCode.Single:
                        case TypeCode.UInt16:
                        case TypeCode.UInt32:
                        case TypeCode.UInt64:
                            boolval = (int)obj == 1;
                            break;
                        case TypeCode.Boolean:
                            boolval = (bool)obj;
                            break;
                        case TypeCode.String:
                            boolval = (string)obj == "True" || (string)obj == "true" || (string)obj == "on";
                            break;
                        case TypeCode.Char:
                            boolval = (string)obj == "1";
                            break;
                        case TypeCode.Object:
                        case TypeCode.Empty:
                        case TypeCode.DateTime:
                        case TypeCode.DBNull:
                            boolval = false;
                            break;
                    }
                }
                catch (Exception)
                {
                    boolval = false;
                }
                return boolval;
            }
            public static DateTime GetDateTime(this object obj)
            {
                try
                {
                    return Convert.ToDateTime(obj.ToString());
                }
                catch
                {
                    return DateTime.MinValue.Date;
                }
            }
            public static string GetString(this object obj)
            {
                try
                {
                    return Convert.ToString(obj.ToString().Trim());
                }
                catch
                {
                    return "";
                }
            }
            public static double GetDouble(this object obj)
            {
                try
                {
                    return Convert.ToDouble(obj.ToString());
                }
                catch
                {
                    return 0;
                }
            }
            public static float GetFloat(this object obj)
            {
                try
                {
                    return Convert.ToSingle(obj.ToString());
                }
                catch
                {
                    return 0;
                }
            }
            public static decimal GetDecimal(this object obj)
            {
                decimal result = 0;
                try
                {
                    if (obj != null)
                    {
                        result = Convert.ToDecimal(obj);
                    }
                }
                catch (Exception)
                {
                }

                return result;
            }
            public static bool IsNull(this object obj)
            {
                try
                {
                    return String.IsNullOrEmpty(obj.ToString());
                }
                catch
                {
                    return true;
                }
            }
            public static bool IsNullOrZero(this object obj)
            {
                try
                {
                    if (obj == null)
                    {
                        return true;
                    }
                    if (obj is int || obj is long || obj is double || obj is float || obj is decimal)
                    {
                        return obj.GetDecimal() == 0;
                    }
                    else if (obj is string)
                    {
                        if (!obj.IsNull())
                        {
                            return (string)obj == "0";
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                catch
                {
                    return true;
                }

            }
        }
}
