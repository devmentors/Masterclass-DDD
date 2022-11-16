namespace Micro.Contexts.Accessors;

public sealed class ContextAccessor : IContextAccessor
{
    private static readonly AsyncLocal<ContextHolder> Holder = new();

    public IContext? Context
    {
        get => Holder.Value?.Context;
        set
        {
            var holder = Holder.Value;
            if (holder != null)
            {
                holder.Context = null;
            }

            if (value is not null)
            {
                Holder.Value = new ContextHolder {Context = value};
            }
        }
    }

    private class ContextHolder
    {
        public IContext? Context;
    }
}