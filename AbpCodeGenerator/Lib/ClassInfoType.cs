using AbpCodeGenerator.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpCodeGenerator.Lib
{
	public class ClassInfoType
	{
		public string ClassName { get; set; }
		public Type ObjType { get; set; }
		public List<MetaTableInfo> MetaTableInfos { get; set; }
	}
}
