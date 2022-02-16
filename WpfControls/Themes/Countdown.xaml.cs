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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControls.Themes
{
    /// <summary>
    /// Countdown.xaml 的交互逻辑
    /// </summary>
    public partial class Countdown : UserControl
    {
        public static readonly DependencyProperty CountdownProperty = DependencyProperty.Register("txtName", typeof(string), typeof(Countdown), new PropertyMetadata(""));
        public string CountdownText
        {
            get { return (string)GetValue(CountdownProperty); }
            set { SetValue(CountdownProperty, value); }
        }
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("rotateCon", typeof(string), typeof(Countdown), new PropertyMetadata(""));
        public string HtForeground
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public Countdown()
        {
            InitializeComponent();
            CreateAnimation(rotateCon);
        }

        public void CreateAnimation(Border value)
        {
            //设置旋转的方向
            RotateTransform rotate = new RotateTransform();
            //给对象绑定旋转中心
            value.RenderTransform = rotate;
            //旋转中心设置(百分比)
            value.RenderTransformOrigin = new Point(0.5, 0.5);

            Storyboard story = new Storyboard();//1.找剧本,故事本
            DoubleAnimation da = new DoubleAnimation(0, 360, new Duration(TimeSpan.FromSeconds(2)));//两点动画:差值动画; 括号里设置动画的起始值,动画的终止值,动画的进行时间;
            Storyboard.SetTarget(da, value); //设置某个动画
            //设置动画的属性
            Storyboard.SetTargetProperty(da, new PropertyPath("RenderTransform.Angle"));//欧拉角
            da.RepeatBehavior = RepeatBehavior.Forever;//重复
            story.Children.Add(da);
            story.Begin();
        }
    }
}
