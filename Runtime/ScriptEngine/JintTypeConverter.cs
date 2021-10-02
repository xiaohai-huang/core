#if !REACT_DISABLE_JINT
#define REACT_JINT
#endif

#if REACT_JINT
using System;
using Jint;
using Jint.Native;
using Jint.Native.Function;
using Jint.Runtime.Interop;
using ReactUnity.Helpers;

namespace ReactUnity.ScriptEngine
{
    public class JintTypeConverter : DefaultTypeConverter
    {
        private Engine Engine;

        public JintTypeConverter(Engine engine) : base(engine)
        {
            Engine = engine;
        }

        public override object Convert(object value, Type type, IFormatProvider formatProvider)
        {
            if (type == typeof(Callback) || type == typeof(object))
            {
                if (value is Func<JsValue, JsValue[], JsValue> cb)
                {
                    return new Callback(cb, Engine);
                }

                if (value is FunctionInstance fi)
                {
                    return new Callback(fi);
                }
            }

            return base.Convert(value, type, formatProvider);
        }
    }
}
#endif