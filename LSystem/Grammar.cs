using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LSystem
{
    public class Grammar
    {
        private List<string> variables;
        private List<string> constants;
        private Dictionary<string, string> rules;
        public string Start { get; set; }

        public Grammar()
        {
            variables = new List<string>();
            constants = new List<string>();
            Start = "";
            rules = new Dictionary<string, string>();
        }

        //规则迭代
        public string Iteration(int n)
        {
            //string[] ruleName = new string[20];
            //int k = 0;
            //foreach (var item in rules)
            //{
            //    ruleName[k] = item.Key;
            //    k++;
            //}
            string result = "";
            string[] ss = Start.Split(' ');
            for (int i = 0; i < n; i++)
            {
                StringBuilder temp = new StringBuilder();
                for (int j = 0; j < ss.Length; j++)
                {
                    if (constants.Contains(ss[j]))
                    {
                        temp.Append(ss[j]);
                        temp.Append(' ');
                    }
                    else if (variables.Contains(ss[j])&&rules.ContainsKey(ss[j]))
                    {
                        //if (ruleName[i % k].Equals(ss[j])){
                            temp.Append(rules[ss[j]]);
                            temp.Append(' ');
                        //}
                        //else
                        //{
                        //    temp.Append(ss[j]);
                        //    temp.Append(' ');
                        //}
                    }
                    else return "";
                }
                if (i == n - 1)
                {
                    result = temp.ToString();
                }
                else ss = temp.ToString().Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            return result;
        }


        #region >>>>>>>>>get and set

        #region >>>>>>>>>variables
        //添加变量
        public void AddVar(string var)
        {
            variables.Add(var);
        }
        //删除变量
        public bool DelVar(string var)
        {
            return variables.Remove(var);
        }
        //清空变量
        public void ClearVar()
        {
            variables.Clear();
        }
        //获得所有变量
        public List<string> GetALLVar()
        {
            return variables;
        }
        #endregion

        #region >>>>>>>>>constants
        //添加常量
        public void AddConst(string constant)
        {
            constants.Add(constant);
        }
        //删除常量
        public bool DelConst(string constant)
        {
            return constants.Remove(constant);
        }
        //清空常量
        public void ClearConst()
        {
            constants.Clear();
        }
        //获得所有常量
        public List<string> GetALLConst()
        {
            return constants;
        }
        #endregion

        #region >>>>>>>>>rules
        //添加规则
        public bool AddRules(string nonTerminals, string rule)
        {
            if (!rules.ContainsKey(nonTerminals))
            {
                rules.Add(nonTerminals, rule);
                return true;
            }
            else return false;
        }
        //删除规则
        public void DelRules(string nonTerminals)
        {
            rules.Remove(nonTerminals);
        }
        //清空规则
        public void ClearRuels()
        {
            rules.Clear();
        }
        //查询规则
        public string GetRuel(string nonTerminals)
        {
            return rules[nonTerminals];
        }
        //获得所有规则
        public Dictionary<string,string> GetALLRules()
        {
            return rules;
        }
        #endregion
        #endregion
    }
}