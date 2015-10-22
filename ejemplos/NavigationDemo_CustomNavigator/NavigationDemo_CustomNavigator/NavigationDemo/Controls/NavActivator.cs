using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace NavigationDemo
{
    public class NavActivator
    {
        #region Fields
        private static NavActivator _instance;
        private Dictionary<Uri, object> _entries = new Dictionary<Uri, object>();
        #endregion //Fields

        #region .ctor
        public NavActivator() 
        {
        }
        #endregion //.ctor

        #region Methods
        private void Register(Uri uri, object item)
        {
            if (uri == null || item == null)
                throw new ApplicationException();

            _entries[uri] = item;
        }
        public object Resolve(Uri uri)
        {
            object item;

            if (uri != null && _entries.TryGetValue(uri, out item))
            {
                return item;
            }
            return null;
        }
        public object Create(Uri uri, object[] parameters)
        {
            object item = Resolve(uri);

            if (item != null)
                return item;

            ConstructorInfo ctor = typeof(NavCommandItem).GetConstructor(new Type[] {typeof(NavScroller),typeof(Uri)});
            if (ctor != null)
            {
                item = ctor.Invoke(parameters);
                Register(uri, item);
                return item;
            }
            return null;
        }
        #endregion //Methods

        #region Properties
        public static NavActivator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NavActivator();

                return _instance;
            }
        }
        #endregion //Properties
    }
}
