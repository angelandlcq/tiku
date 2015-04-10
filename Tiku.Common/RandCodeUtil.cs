using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**************************************************************************
 * 
 * Author:
 * Date:
 * Description:
 * Mark:
 * 
 * **********************************************************************/
namespace TiKu.Common
{
    public class RandCodeUtil
    {
        /// <summary>
        /// 生成指定长度的随机数
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static string RandCode(int N)
        {
            char[] arrChar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            StringBuilder num = new StringBuilder();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < N; i++)
            {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }
            return num.ToString();
        }

        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="Count"></param>
        /// <returns></returns>
        public static int[] CreateRandomNumbers(int Count)
        {
            int[] arr = new int[Count];
            int max2 = Count + 1;
            Dictionary<int, bool> dy = new Dictionary<int, bool>(Count);

            Random rd = new Random();
            int num;
            for (int i = 0; i < arr.Length; )
            {
                num = rd.Next(0, Count + 1);
                if (!dy.ContainsKey(num))
                {
                    dy.Add(num, true);
                    arr[i] = num;
                    i++;
                }

            }
            dy.Clear();
            return arr;
        }

        #region 高度随机数生成
        /// 构造随机数 种子
        public static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        ///  生成随机 数
        public static int rnd()
        {

            Random ran = new Random(GetRandomSeed());
            int cnt = ran.Next(0, 59);
            return cnt;
        }
        #endregion
    }
}
