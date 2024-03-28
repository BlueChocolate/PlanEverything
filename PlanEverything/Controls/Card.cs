using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace PlanEverything.Controls
{
    [ContentProperty("Content")]
    public class Card : Control
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Card), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty TitleForegroundProperty = DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(Card), new PropertyMetadata(Brushes.Black));
        
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(Card), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty DescriptionForegroundProperty = DependencyProperty.Register("DescriptionForeground", typeof(Brush), typeof(Card), new PropertyMetadata(Brushes.Gray));
        
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(object), typeof(Card), new PropertyMetadata(null));
        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register("IconHeight", typeof(double), typeof(Card), new PropertyMetadata(16.0));
        public static readonly DependencyProperty IconMinHeightProperty = DependencyProperty.Register("IconMinHeight", typeof(double), typeof(Card), new PropertyMetadata(32.0));
        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register("IconWidth", typeof(double), typeof(Card), new PropertyMetadata(16.0));
        public static readonly DependencyProperty IconMinWidthProperty = DependencyProperty.Register("IconMinWidth", typeof(double), typeof(Card), new PropertyMetadata(32.0));
        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register("IconMargin", typeof(Thickness), typeof(Card), new PropertyMetadata(new Thickness(0)));
        public static readonly DependencyProperty IconFontSizeProperty = DependencyProperty.Register("IconFontSize", typeof(double), typeof(Card), new PropertyMetadata(16.0));
        public static readonly DependencyProperty IconFontFamilyProperty = DependencyProperty.Register("IconFontFamily", typeof(FontFamily), typeof(Card), new PropertyMetadata(new FontFamily("Segoe MDL2 Assets")));
        public static readonly DependencyProperty IconFontForegroundProperty = DependencyProperty.Register("IconFontForeground", typeof(Brush), typeof(Card), new PropertyMetadata(Brushes.Black));
        
        public static readonly DependencyProperty ContentPositionProperty = DependencyProperty.Register("ContentPosition", typeof(ContentPosition), typeof(Card), new PropertyMetadata(ContentPosition.Bottom));
        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(Card), new PropertyMetadata(null));
        
        public static new readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(Card), new PropertyMetadata(Brushes.Transparent));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public Brush TitleForeground
        {
            get { return (Brush)GetValue(TitleForegroundProperty); }
            set { SetValue(TitleForegroundProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public Brush DescriptionForeground
        {
            get { return (Brush)GetValue(DescriptionForegroundProperty); }
            set { SetValue(DescriptionForegroundProperty, value); }
        }

        public object Icon
        {
            get { return GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }

        public double IconMinHeight
        {
            get { return (double)GetValue(IconMinHeightProperty); }
            set { SetValue(IconMinHeightProperty, value); }
        }

        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        public double IconMinWidth
        {
            get { return (double)GetValue(IconMinWidthProperty); }
            set { SetValue(IconMinWidthProperty, value); }
        }

        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }

        public FontFamily IconFontFamily
        {
            get { return (FontFamily)GetValue(IconFontFamilyProperty); }
            set { SetValue(IconFontFamilyProperty, value); }
        }

        public Brush IconFontForeground
        {
            get { return (Brush)GetValue(IconFontForegroundProperty); }
            set { SetValue(IconFontForegroundProperty, value); }
        }

        public double IconFontSize
        {
            get { return (double)GetValue(IconFontSizeProperty); }
            set { SetValue(IconFontSizeProperty, value); }
        }


        public ContentPosition ContentPosition
        {
            get { return (ContentPosition)GetValue(ContentPositionProperty); }
            set { SetValue(ContentPositionProperty, value); }
        }

        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        static Card()
        {
            // 默认使用 Themes/Generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Card), new FrameworkPropertyMetadata(typeof(Card)));
        }
    }

    public class ContentPositionToGridAttributeConverter : IValueConverter
    {
        private readonly int[,] _gridAttributeArray = {
            // 按照 GridAttribute 的顺序排列
            { 1, 1, 0, 1 }, // Default
            { 1, 1, 0, 1 }, // Button
            { 0, 1, 2, 1 }  // Right
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
}
