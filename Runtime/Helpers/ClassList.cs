using System;

namespace ReactUnity.Helpers
{
    public class ClassList : WatchableSet<string>
    {
        private readonly IReactComponent Component;

        private string name;
        public string Name
        {
            get
            {
                if (name == null) name = string.Join(" ", this);
                return name;
            }
            set
            {
                OnBeforeChange();
                ClearWithoutNotify();

                if (!string.IsNullOrWhiteSpace(value))
                {
                    var classes = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < classes.Length; i++)
                        AddWithoutNotify(classes[i]);
                }
                OnAfterChange();
            }
        }

        public ClassList(IReactComponent component)
        {
            Component = component;
        }

        internal override void OnAdd(string item)
        {
            name = null;
            Component.MarkForStyleResolving(true);
        }

        internal override void OnRemove(string item)
        {
            name = null;
            Component.MarkForStyleResolving(true);
        }

        internal override void OnBeforeChange()
        {
            name = null;
        }

        internal override void OnAfterChange()
        {
            Component.MarkForStyleResolving(true);
        }
    }
}
