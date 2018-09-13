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

namespace WPFDataGridPaging
{
    /// <summary>
    /// Pagger2.xaml 的交互逻辑
    /// </summary>
    public partial class Pagger : UserControl
    {
        public static RoutedEvent FirstPageEvent;
        public static RoutedEvent PreviousPageEvent;
        public static RoutedEvent NextPageEvent;
        public static RoutedEvent LastPageEvent;        

        public static readonly DependencyProperty CurrentPageProperty;
        public static readonly DependencyProperty TotalPageProperty;
        public static readonly DependencyProperty PageSizeProperty;

        /// <summary>
        /// 默认PageSize        
        /// </summary>
        private const int DEFAULT_PAGE_SIZE = 10;

        public string CurrentPage
        {
            get { return (string)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        public string TotalPage
        {
            get { return (string)GetValue(TotalPageProperty); }
            set { SetValue(TotalPageProperty, value); }
        }
        
        public string PageSize
        {
            get { return (string)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        public Pagger()
        {
            InitializeComponent();
        }

        static Pagger()
        {
            FirstPageEvent = EventManager.RegisterRoutedEvent("FirstPage", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(Pagger));
            PreviousPageEvent = EventManager.RegisterRoutedEvent("PreviousPage", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(Pagger));
            NextPageEvent = EventManager.RegisterRoutedEvent("NextPage", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(Pagger));
            LastPageEvent = EventManager.RegisterRoutedEvent("LastPage", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(Pagger));

            CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(string), typeof(Pagger), new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnCurrentPageChanged)));
            TotalPageProperty = DependencyProperty.Register("TotalPage", typeof(string), typeof(Pagger), new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnTotalPageChanged)));
            PageSizeProperty = DependencyProperty.Register("PageSize", typeof(string), typeof(Pagger), new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnPageSizeChanged)));
        }

        public event RoutedEventHandler FirstPage
        {
            add { AddHandler(FirstPageEvent, value); }
            remove { RemoveHandler(FirstPageEvent, value); }
        }

        public event RoutedEventHandler PreviousPage
        {
            add { AddHandler(PreviousPageEvent, value); }
            remove { RemoveHandler(PreviousPageEvent, value); }
        }

        public event RoutedEventHandler NextPage
        {
            add { AddHandler(NextPageEvent, value); }
            remove { RemoveHandler(NextPageEvent, value); }
        }

        public event RoutedEventHandler LastPage
        {
            add { AddHandler(LastPageEvent, value); }
            remove { RemoveHandler(LastPageEvent, value); }
        }

        public static void OnTotalPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var p = d as Pagger;

            if (p != null)
            {
                var totalPage = (string)e.NewValue;

                var rTotal = (Run)p.FindName("rTotal");
                rTotal.Text = totalPage;

                var totalRecordCountControl = p.FindName("totalRecordCount") as Run;
                totalRecordCountControl.Text = (int.Parse(totalPage) * int.Parse(p.PageSize)).ToString();
            }
        }

        public static void OnPageSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var p = d as Pagger;

            if (p != null)
            {
                var newPageSize = (string)e.NewValue;

                // 检查传入的pageSize是否约定的Item值，否则规范为DEFAULT_PAGE_SIZE
                var cbx = (ComboBox)p.FindName("cb_pageSize");

                var allItems = cbx.Items;

                bool bIsFindGivenVal = false;

                foreach (var eItem in allItems)
                {
                    var eCbxItem = eItem as ComboBoxItem;

                    if (eCbxItem.Content.ToString() == newPageSize)
                    {
                        bIsFindGivenVal = true;
                        break;
                    }
                }

                if (!bIsFindGivenVal) newPageSize = DEFAULT_PAGE_SIZE.ToString();

                cbx.SelectedValue = newPageSize;
            }
        }

        private static void OnCurrentPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var p = d as Pagger;

            if (p != null)
            {
                Run rCurrrent = (Run)p.FindName("rCurrent");

                rCurrrent.Text = (string)e.NewValue;
            }
        }

        private void FirstPageButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FirstPageEvent, this));
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(PreviousPageEvent, this));
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NextPageEvent, this));
        }

        private void LastPageButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(LastPageEvent, this));
        }        

        private void btn_go_Click(object sender, RoutedEventArgs e)
        {
            var goPageVal = tbx_goPageCount.Text;
            int nGoPage = 0;
            int nMaxPage = int.Parse(TotalPage);
            if(int.TryParse(goPageVal,out nGoPage))
            {
                if(nGoPage <= 1)
                {
                    CurrentPage = "1";
                    RaiseEvent(new RoutedEventArgs(FirstPageEvent, this));
                    return;
                }
                else if(nGoPage >= nMaxPage)
                {
                    CurrentPage = TotalPage;
                    RaiseEvent(new RoutedEventArgs(LastPageEvent, this));
                    return;
                }
                else
                {
                    CurrentPage = (nGoPage--).ToString();
                    RaiseEvent(new RoutedEventArgs(NextPageEvent, this));
                }
            }
        }
    }
}
