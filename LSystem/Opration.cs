using System;
using System.Collections.Generic;
using System.Text;

namespace LSystem
{
    public class Opration
    {
        private double x;
        private double y;
        private double angle;
        private double currentAngle;
        public double LineLen { get; set;}
        public double X { get => x; }
        public double Y { get => y; }
        public double Angle { get => angle;}

        private Stack<double> stack;

        public Opration(double x, double y, double angle)
        {
            this.x = x;
            this.y = y;
            this.angle = angle;
            LineLen = 20;
            currentAngle = 0;
            stack = new Stack<double>();
        }
        
        //以当前方向前进一步，并画线
        public double[] DrawLine()
        {
            double[] result = new double[4];
            result[0] = x;
            result[1] = y;
            double d = currentAngle * Math.PI / 180;
            y += Math.Cos(d) * LineLen;
            x += Math.Sin(d) * LineLen;
            result[2] = x;
            result[3] = y;
            return result;
        }

        //以当前方向前进一步，不画线
        public void Forward()
        {
            double d = currentAngle * Math.PI / 180;
            x += Math.Cos(d) * LineLen;
            y += Math.Sin(d) * LineLen;
        }

        //逆时针旋转angle度
        public void TurnL()
        {
            currentAngle += angle;
            
        }

        //顺时针旋转angle度
        public void TrunR()
        {
            currentAngle -= angle;
        }
        //将当前信息压栈
        public void Push()
        {
            stack.Push(x);
            stack.Push(y);
            stack.Push(currentAngle);
        }
        //将当前信息出栈
        public void Pop()
        {
            currentAngle = stack.Pop();
            y = stack.Pop();
            x = stack.Pop();
        }
    }
}
