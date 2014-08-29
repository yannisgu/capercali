using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Capercali.WPF
{
    public static class ReactiveListExtensions
    {
        public static void ForEach<T>(this ReactiveList<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }
    }
}
