using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LSystem;

namespace UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //解析文法
        private void Parse()
        {
            Grammar grammar = new Grammar();
            //添加变量
            string[] ss = var.Text.Split(',');
            for (int i = 0; i < ss.Length; i++)
            {
                grammar.AddVar(ss[i]);
            }
            //添加常量
            ss = @const.Text.Split(new char[1] { ','}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ss.Length; i++)
            {
                grammar.AddConst(ss[i]);
            }
            //添加初始项
            grammar.Start = start.Text;
            //添加规则
            ss = rules.Text.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ss.Length; i++)
            {
                string[] sss = ss[i].Split(new string[1] { "->"}, StringSplitOptions.RemoveEmptyEntries);
                if (sss.Length == 2) grammar.AddRules(sss[0], sss[1]);
                else
                {
                    result.Text = "Error";
                    return;
                }
            }
            //规则迭代
            string res = grammar.Iteration(int.Parse(n.Text));
            result.Text = res;
            Draw(res);
        }

        //draw
        private void Draw(string s)
        {
            string[] ss = XY.Text.Split(',');
            Opration opration = new Opration(double.Parse(ss[0]), double.Parse(ss[1]), double.Parse(angle.Text))
            {
                LineLen = double.Parse(len.Text)
            };
            ss = s.Split(new char[1] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in ss)
            {
                if ("[".Equals(item))
                {
                    opration.Push();
                }
                else if ("]".Equals(item))
                {
                    opration.Pop();
                }
                else if ("+".Equals(item))
                {
                    opration.TurnL();
                }
                else if ("-".Equals(item))
                {
                    opration.TrunR();
                }
                else if ("F".Equals(item)||"V".Equals(item)||"L".Equals(item)||"R".Equals(item) || "G".Equals(item) || "A".Equals(item) || "B".Equals(item))
                {
                    double[] points = opration.DrawLine();
                    Line line = new Line
                    {
                        X1 = points[2],
                        Y1 = points[3],
                        X2 = points[0],
                        Y2 = points[1],
                        Stroke = Brushes.Green,
                    };

                    canvas.Children.Add(line);
                }
                else if ("f".Equals(item))
                {
                    opration.Forward();
                }
            }
        }

        #region >>>>>>>>>Click
        private void Begin_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            Parse();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            var.Text = "";
            @const.Text = "";
            start.Text = "";
            rules.Text = "";
            n.Text = "";
            angle.Text = "";
        }
        #endregion

    }
}
