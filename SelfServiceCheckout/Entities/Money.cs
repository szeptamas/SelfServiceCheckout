using System;

namespace SelfServiceCheckout
{
	public class Money
	{
		public Guid Id { get; set; }
		public int? Value { get; set; }
		public string Key { get; set; }
		public bool InStock
		{
			get { return InStock; }
			set { InStock = Value == 0 ? false : true; }
		}
	}
}
