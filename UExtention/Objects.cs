

using System;

namespace UExtensionLibrary.Objects
{
    public static class Objects
    {

        public static object SafeValue(this object objBase)
        {

            if (DBNull.Value.Equals(objBase)) objBase = null;
            return objBase;
        }
        
    }
}
