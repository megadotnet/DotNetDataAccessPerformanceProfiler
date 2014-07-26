using System;
using NHibernate.Type;

namespace NH
{
	public class ParamInfo 
	{
		private string name; 
		private object value;
		private IType type;
		public ParamInfo( string name, object value, IType type ) 
		{
			this.name = name;
			this.value = value;
			this.type = type;
		} 
		public string Name 
		{
			get { return name; }
		} 
		public object Value 
		{
			get { return value; }
		} 
		public IType Type 
		{
			get { return type; }
		} 
	} 
}
