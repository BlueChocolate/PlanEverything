
using System.Windows;
using System.Windows.Controls;

namespace PlanEverything.Helpers
{
    public class GridHelper
    {
        public static readonly DependencyProperty RowDefinitionsProperty =
            DependencyProperty.RegisterAttached("RowDefinitions", typeof(string), typeof(GridHelper), new PropertyMetadata(string.Empty, RowDefinitionsChanged));

        public static readonly DependencyProperty ColumnDefinitionsProperty =
            DependencyProperty.RegisterAttached("ColumnDefinitions", typeof(string), typeof(GridHelper), new PropertyMetadata(string.Empty, ColumnDefinitionsChanged));

        public static string GetRowDefinitions(DependencyObject obj)
        {
            return (string)obj.GetValue(RowDefinitionsProperty);
        }

        public static void SetRowDefinitions(DependencyObject obj, string value)
        {
            obj.SetValue(RowDefinitionsProperty, value);
        }

        public static string GetColumnDefinitions(DependencyObject obj)
        {
            return (string)obj.GetValue(ColumnDefinitionsProperty);
        }

        public static void SetColumnDefinitions(DependencyObject obj, string value)
        {
            obj.SetValue(ColumnDefinitionsProperty, value);
        }

        private static void RowDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not Grid grid || e.NewValue == null) 
                return;

            grid.RowDefinitions.Clear();
            var rowDefinitions = ((string)e.NewValue).Split(',').Select(s => s.Trim());

            foreach (var rowDefinition in rowDefinitions)
            {
                var length = ParseGridLength(rowDefinition);
                grid.RowDefinitions.Add(new RowDefinition { Height = length });
            }
        }

        private static void ColumnDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not Grid grid || e.NewValue == null)
                return;

            grid.ColumnDefinitions.Clear();
            var columnDefinitions = ((string)e.NewValue).Split(',').Select(s => s.Trim());

            foreach (var columnDefinition in columnDefinitions)
            {
                var length = ParseGridLength(columnDefinition);
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = length });
            }
        }

        private static GridLength ParseGridLength(string length)
        {
            if (length.EndsWith('*'))
            {
                double star = 1;
                if (length.Length > 1)
                {
                    if (double.TryParse(length[..^1], out var value))
                    {
                        star = value;
                    }
                }
                return new GridLength(star, GridUnitType.Star);
            }
            else if (length.Equals("Auto", StringComparison.OrdinalIgnoreCase))
            {
                return GridLength.Auto;
            }
            else if (double.TryParse(length, out var pixels))
            {
                return new GridLength(pixels);
            }

            throw new ArgumentException($"Invalid length value: {length}");
        }
    }
}
