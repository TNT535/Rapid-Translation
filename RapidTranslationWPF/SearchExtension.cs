using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;


namespace RapidTranslationWPF
{
    public static class SearchExtension
    {
        public static IEnumerable<T> FindVisualChildren<T>([NotNull] this DependencyObject parent) where T : DependencyObject
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            var queue = new Queue<DependencyObject>(new[] { parent });

            while (queue.Any())
            {
                var reference = queue.Dequeue();
                var count = VisualTreeHelper.GetChildrenCount(reference);

                for (var i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(reference, i);
                    if (child is T children)
                        yield return children;

                    queue.Enqueue(child);
                }
            }
        }

        public static IEnumerable<T> FindLogicalChildren<T>([NotNull] this DependencyObject parent) where T : DependencyObject
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            var queue = new Queue<DependencyObject>(new[] { parent });

            while (queue.Any())
            {
                var reference = queue.Dequeue();
                var children = LogicalTreeHelper.GetChildren(reference);
                var objects = children.OfType<DependencyObject>();

                foreach (var o in objects)
                {
                    if (o is T child)
                        yield return child;

                    queue.Enqueue(o);
                }
            }
        }



    }
}
