using System;

namespace NH
{
	public class PagerInfo 
	{
		private int firstResult; 

		private int maxResults; 
		public PagerInfo( int firstResult, int maxResults ) 
		{
			this.firstResult = firstResult;
			this.maxResults = maxResults;
		}
		public int FirstResult 
		{
			get { return firstResult; }
		}
		public int MaxResults 
		{
			get { return maxResults; }
		}
	}

}
