using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
	public class Value
	{
		public string Value_uuid { get; set; }
		public string Parent_parameter_uuid { get; set; }
		public int Timestamp_start { get; set; }
		public int Timestamp_end { get; set; }
		public object Data { get; set; }
	}
}


//namespace Utility
//{
//    public class Value<T>
//    {
//        public string Value_uuid { get; set; }
//        public string Parent_parameter_uuid { get; set; }
//        public int Timestamp_start { get; set; }
//        public int Timestamp_end { get; set; }
//        public T Data { get; set; }
//    }
//}
