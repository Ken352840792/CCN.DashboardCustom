using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace CCN.DashboardCustom.Secutiry
{
    /// <summary>
    /// 字符串Hash操作类
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// 获取字符串的MD5哈希值，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        public static string GetMd5(string value, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] bytes = encoding.GetBytes(value);
            return GetMd5(bytes);
        }

        /// <summary>
        /// 获取字节数组的MD5哈希值
        /// </summary>
        public static string GetMd5(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            MD5 hash = new MD5CryptoServiceProvider();
            bytes = hash.ComputeHash(bytes);
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取字符串的SHA1哈希值，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        public static string GetSha1(string value, Encoding encoding = null)
        {
            StringBuilder sb = new StringBuilder();
            SHA1Managed hash = new SHA1Managed();
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] bytes = hash.ComputeHash(encoding.GetBytes(value));
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取字符串的Sha256哈希值，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        public static string GetSha256(string value, Encoding encoding = null)
        {
            StringBuilder sb = new StringBuilder();
            SHA256Managed hash = new SHA256Managed();
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] bytes = hash.ComputeHash(encoding.GetBytes(value));
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取字符串的Sha512哈希值，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        public static string GetSha512(string value, Encoding encoding = null)
        {
            StringBuilder sb = new StringBuilder();
            SHA512Managed hash = new SHA512Managed();
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] bytes = hash.ComputeHash(encoding.GetBytes(value));
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }


        /// <summary>  
        /// 获取文件的MD5码  
        /// </summary>  
        /// <param name="fileName">传入的文件名（含路径及后缀名）</param>  
        /// <returns></returns>  
        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, System.IO.FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }

    }
}
