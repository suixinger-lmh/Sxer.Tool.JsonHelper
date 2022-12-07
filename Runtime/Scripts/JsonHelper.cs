using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sxer.Tool
{
    public static class JsonHelper
    {

        #region need LitJson

        public static string Object2JsonStr(object obj)
        {
            try
            {
                string jsonStr = LitJson.JsonMapper.ToJson(obj);
                //反编译防止乱码，替换反斜杠
                jsonStr = System.Text.RegularExpressions.Regex.Unescape(jsonStr).Replace('\\', '/');
                return jsonStr;
            }
            catch (Exception ex)
            {
                Debug.LogError("json生成异常！"+ex.Message);
                return null;
            }
        }


        public static T JsonStr2Object<T>(string json)
        {
            try
            {
                return LitJson.JsonMapper.ToObject<T>(json);
            }
            catch (Exception ex)
            {
                Debug.LogError("数据加载失败!" + ex.Message);
                return default(T);
            }
        }

        public static LitJson.JsonData JsonStr2JsonData(string json)
        {
            try
            {
                return LitJson.JsonMapper.ToObject(json);
            }
            catch (Exception ex)
            {
                Debug.LogError("数据加载失败!" + ex.Message);
                return null;
            }
        }
        public static string JsonData2JsonStr(LitJson.JsonData jd)
        {
            try
            {
                string jsonStr = jd.ToJson();
                //反编译防止乱码，替换反斜杠
                jsonStr = System.Text.RegularExpressions.Regex.Unescape(jsonStr).Replace('\\', '/');
                return jsonStr;
            }
            catch (Exception ex)
            {
                Debug.LogError("json生成异常！" + ex.Message);
                return null;
            }
        }


        #endregion


        /// <summary>
        /// 根据键值对生成简单的json(不嵌套)
        /// </summary>
        /// <returns></returns>
        public static string GetEasyJsonStr(string[] keys,string[] values)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("{");
            for(int i = 0; i < keys.Length && i<values.Length; i++)
            {
                stringBuilder.AppendFormat("\"{0}\":\"{1}\"", keys[i], values[i]);
                if (i < keys.Length - 1)
                    stringBuilder.Append(",");
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public static string GetEasyJsonStr(string[] keys, object[] values)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("{");
            for (int i = 0; i < keys.Length && i < values.Length; i++)
            {
                if (values[i] is string)
                    stringBuilder.AppendFormat("\"{0}\":\"{1}\"", keys[i], values[i]);
                else if (values[i] == null)
                    stringBuilder.AppendFormat("\"{0}\":null", keys[i]);
                else
                    stringBuilder.AppendFormat("\"{0}\":{1}", keys[i], values[i]);
                if (i < keys.Length - 1)
                    stringBuilder.Append(",");
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }


    }
}

