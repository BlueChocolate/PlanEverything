using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace PlanEverything.Controls
{
    /// <summary>
    /// Card.xaml 的交互逻辑
    /// </summary>
    //[ContentProperty("InnerContent")]
    public partial class Card : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Card), new PropertyMetadata("Title"));
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(Card), new PropertyMetadata("Description"));
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(Card), new PropertyMetadata(null));
        public static readonly DependencyProperty ContentPositionProperty = DependencyProperty.Register("ContentPosition", typeof(ContentPosition), typeof(Card), new PropertyMetadata(ContentPosition.Bottom));
        //public static readonly DependencyProperty InnerContentProperty = DependencyProperty.Register("InnerContent", typeof(object), typeof(Card), new PropertyMetadata(null));
        
        public static new readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(Card), new PropertyMetadata(Brushes.Transparent));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public ContentPosition ContentPosition
        {
            get { return (ContentPosition)GetValue(ContentPositionProperty); }
            set { SetValue(ContentPositionProperty, value); }
        }

        //public object InnerContent
        //{
        //    get { return GetValue(InnerContentProperty); }
        //    set { SetValue(InnerContentProperty, value); }
        //}

        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public Card()
        {
            InitializeComponent(); 
        }

    }
    public enum ContentPosition
    {
        Default = 0,
        Bottom,
        Right
    }
    public enum GridAttribute
    {
        Row = 0,
        RowSpan,
        Column,
        ColumnSpan
    }

    public class ContentPositionToGridAttributeConverter : IValueConverter
    {
        private readonly int[,] _gridAttributeArray = {
            // 按照 GridAttribute 的顺序排列
            { 2, 1, 0, 2 }, // Default
            { 2, 1, 0, 2 }, // Button
            { 0, 2, 1, 1 }  // Right
        };
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is ContentPosition cardType && parameter is string attribute)
            {
                if (Enum.TryParse<GridAttribute>(attribute, out var gridAttribute))
                {
                    return _gridAttributeArray[(int)cardType, (int)gridAttribute];
                }
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
