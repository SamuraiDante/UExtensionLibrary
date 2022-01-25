using System;
using System.Linq;
using System.Reflection;

namespace UExtensionLibrary.Methods
{
	public static class Conversion
	{
		public static T2 MemberwiseConvert<T1, T2>(T1 Source) where T2 : new()
		{
			T2 ReturnValue = new T2();
			Type SourceType = typeof(T1);
			PropertyInfo[] Members = SourceType.GetProperties().ToArray();
			Type DestinationType = typeof(T2);
			foreach(PropertyInfo Member in Members)
			{
				object Value = Member.GetValue(Source);

				DestinationType.GetProperty(Member.Name).SetValue(ReturnValue, Value);
			}
			return ReturnValue;
		}

		public static T MemberwiseDynamicCast<T>(dynamic Source) where T : new()
		{
			T ReturnValue = new T();
			Type DestinationType = typeof(T);
			PropertyInfo[] Properties = DestinationType.GetProperties().ToArray();
			foreach(PropertyInfo Property in Properties)
			{
				foreach(var Member in Source)
				{
					if(Member.Key == Property.Name)
					{
						Property.SetValue(ReturnValue, Member.Value);
					}
				}
			}
			return ReturnValue;
		}
	}
}
