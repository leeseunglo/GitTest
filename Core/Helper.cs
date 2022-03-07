using System;
using System.IO;

namespace Core
{
	public class FileHelper
	{
		public static void CreateDirectory(string strFilePath)
		{
			string strPath = Path.GetDirectoryName(strFilePath);
			DirectoryInfo di = new DirectoryInfo(strPath);
			if (true == di.Exists)
				return;

			di.Create();
		}

		public static bool ExistFile(string strFileName)
		{
			return new FileInfo(strFileName).Exists;
		}

		public static void DeleteFile(string strFileName)
		{
			FileInfo info = new FileInfo(strFileName);
			if (false == info.Exists)
				return;

			File.Delete(strFileName);
		}
	}

	public class ConvertHelper
	{
		public static T GetEnumValue<T>(string strValue) where T : struct
		{
			T eType;
			if (false == Enum.TryParse(strValue, out eType))
				throw new Exception($"GetEnumValue fail. {strValue}");

			return eType;
		}
	}
}
