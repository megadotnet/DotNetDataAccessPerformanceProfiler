using System;

namespace NH
{
	public class BizObject 
	{
		public BizObject() { }

		public BizObject( object existingId ) 
		{
			ObjectBroker.Load( this, existingId );
		}
		public virtual void Create() 
		{
			ObjectBroker.Create( this );
		}
		public virtual void Update() 
		{
			ObjectBroker.Update( this );
		}
		public virtual void Delete() 
		{
			ObjectBroker.Delete( this );
		}
	}
}
