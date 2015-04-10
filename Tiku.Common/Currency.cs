using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public static class Currency
    {
        #region 人民币大写
        /// <summary>
        /// 人民币大写
        /// </summary>
        /// <param name="input">待转换输入</param>
        /// <param name="prefix">需要添加人民币前缀</param>
        /// <exception cref="ArgumentException" />
        /// <returns>转换后的结果</returns>
        public static string ToCapital(this string input, bool prefix = false)
        {

            #region Step1 输入有效性验证

            if (!Regex.IsMatch(input, @"(?<=-|^)\d*\.?\d*$"))
                throw new ArgumentException("错误的输入金额！");

            if (Regex.IsMatch(input, @"^\d{25,}"))
                throw new ArgumentException("输入数据太大无法转换！");

            #endregion

            #region Step2 格式化为中间字符串

            var positionDic = new Dictionary<int, string> {
        {0,"F"},{1,"J"},{2,"."},{3,"S"},{4,"B"},{5,"Q"},{6,"W"},{7,"SW"},{8,"BW"},{9,"QW"},
        {10,"Y"},{11,"SY"},{12,"BY"},{13,"QY"},{14,"WY"},{15,"SWY"},{16,"BWY"},{17,"QWY"},{18,"YY"},
        {19,"SYY"},{20,"BYY"},{21,"QYY"},{22,"WYY"},{23,"SWYY"},{24,"BWYY"},{25,"QWYY"}               
    };

            input = Regex.Replace(input, @"^\.", "0.");

            var integerPart = Regex.Replace(input, @"^-|\..*$", "");
            var _matchDecimal = Regex.Match(input, @"\.\d*$", RegexOptions.None);
            var decimalPart = Regex.Replace(_matchDecimal.Success ? Convert.ToDouble(_matchDecimal.Value).ToString("0.00") : "00", @"0\.", "");

            var processStack = new Stack<string>();
            var charsArray = (integerPart + decimalPart).Reverse<char>();
            for (int i = 0; i < charsArray.Count(); i++)
            {
                processStack.Push(string.Format("{0}{1}", charsArray.ElementAt(i), positionDic[i]));
            }

            //符号处理
            if (Regex.IsMatch(input, "^-", RegexOptions.None))
            {
                processStack.Push("-");
            }
            if (prefix)
            {
                processStack.Push("￥");
            }

            var process = string.Empty;
            while (processStack.Count > 0)
            {
                process += processStack.Pop();
            }
            //语义处理模式队列
            Queue<Tuple<string, string, MatchEvaluator>> patterns = new Queue<Tuple<string, string, MatchEvaluator>>();
            var patternBuilder = new StringBuilder();
            for (int i = 3; i < positionDic.Count; i++)
            {
                patternBuilder.AppendFormat("{0}{1}", (i == 3 ? "(0(?:" : "") + positionDic[i], i == positionDic.Count - 1 ? ")+?)+" : "|");
            }
            patterns.Enqueue(Tuple.Create<string, string, MatchEvaluator>(patternBuilder.ToString(), "0", null));
            patterns.Enqueue(Tuple.Create<string, string, MatchEvaluator>(@"(?:\d+(?:QW|BW|SW|W|Q|B|S)?\d?YY)+", null, m => m.Value.Replace("YY", "") + "YY"));
            patterns.Enqueue(Tuple.Create<string, string, MatchEvaluator>(@"(?:\d+(?:QW|BW|SW|W|Q|B|S)?\d?Y)+", null, m => m.Value.Replace("Y", "") + "Y"));
            patterns.Enqueue(Tuple.Create<string, string, MatchEvaluator>(@"(?:\d+(?:Q|B|S)?\d?W)+", null, m => m.Value.Replace("W", "") + "W"));
            patterns.Enqueue(Tuple.Create<string, string, MatchEvaluator>(@"(?!^)0+\.", ".", null));
            patterns.Enqueue(Tuple.Create<string, string, MatchEvaluator>(@"^0\.0J|^0\.", "", null));
            patterns.Enqueue(Tuple.Create<string, string, MatchEvaluator>("0J|0F", "0", null));
            patterns.Enqueue(Tuple.Create<string, string, MatchEvaluator>("J0?$", "JZ", null));
            patterns.Enqueue(Tuple.Create<string, string, MatchEvaluator>(@"\.$|\.0+$", ".Z", null));
            patterns.Enqueue(Tuple.Create<string, string, MatchEvaluator>(@"^0+$|^[^.]{0}$", "0.Z", null));

            while (patterns.Count > 0)
            {
                var pattern = patterns.Dequeue();
                if (pattern.Item3 != null)
                {
                    process = Regex.Replace(process, pattern.Item1, pattern.Item3);
                }
                else
                {
                    process = Regex.Replace(process, pattern.Item1, pattern.Item2);
                }
            }

            #endregion

            #region Step3 翻译中间字符串
            StringBuilder result = new StringBuilder();
            var translatorDic = new Dictionary<char, string> {
        {'0',"零"},{'1',"壹"},{'2',"贰"},{'3',"叁"},{'4',"肆"},{'5',"伍"},{'6',"陆"},{'7',"柒"},{'8',"捌"},{'9',"玖"},
        {'S',"拾"},{'B',"佰"},{'Q',"仟"},{'W',"萬"},{'Y',"亿"},
        {'￥',"人民币"},{'-',"负"},{'.',"圆"},{'J',"角"},{'F',"分"},{'Z',"整"}
    };
            for (int i = 0; i < process.Length; i++)
            {
                result.Append(translatorDic[process[i]]);
            }
            #endregion

            return result.ToString();
        }
        #endregion
    }
}
