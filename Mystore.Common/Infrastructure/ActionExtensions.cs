namespace Common.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ActionExtensions
    {
        public static Action OnExceptionContinue(this Action action)
        {
            return () =>
            {
                try
                {
                    action();
                }
                catch
                {
                }
            };
        }
    }
}
