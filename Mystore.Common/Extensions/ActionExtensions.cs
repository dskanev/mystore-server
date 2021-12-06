using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class ActionExtensions
    {
        public static void OnTrue(this bool result, Action action)
        {
            if (!result)
                return;

            action?.Invoke();
        }

        public static void OnFalse(this bool result, Action action)
        {
            if (result)
                return;

            action?.Invoke();
        }

        public static void OnResult(this bool result, Action positive, Action negative)
        {
            if (result)
                result.OnTrue(positive);
            else
                result.OnFalse(negative);
        }

        public static T OnResult<T>(this bool result, T positive, T negative)
        {
            return result ? positive : negative;
        }

        public static T OnTrue<T>(this bool result, Func<T> action)
            => !result ? default(T) : action();

        public static T OnFalse<T>(this bool result, Func<T> action)
            => result ? default(T) : action();

        public static T OnResult<T>(this bool result, Func<T> positive, Func<T> negative)
            => result ? result.OnTrue(positive) : result.OnFalse(negative);
    }
}
