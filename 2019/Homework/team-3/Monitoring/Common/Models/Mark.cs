using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MetricsDbProvider.Models
{
	[DataContract]
	public class Mark
	{
		[DataMember]
		public string ValueUuid { get; set; }

		[DataMember]
		public long TimestampStart { get; set; }

		[DataMember]
		public long TimestampEnd { get; set; }

		[DataMember]
		public object Value { get; set; }

		[DataMember]
		public string MetricsId { get; set; }
	}
}
