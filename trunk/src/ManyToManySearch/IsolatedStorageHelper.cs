using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Xml.Serialization;

namespace ManyToManySearch
{
	public static class IsolatedStorageHelper
	{
		/// <summary>
		/// Don't forget to dispose it
		/// </summary>
		/// <returns></returns>
		private static IsolatedStorageFile GetStorage()
		{
			return AppDomain.CurrentDomain.ActivationContext != null
				? IsolatedStorageFile.GetUserStoreForApplication()
				: IsolatedStorageFile.GetUserStoreForDomain();
		}

		public static string[] LoadAndSplitLines(string filename)
		{
			var data = IsolatedStorageHelper.Load(filename);
			if(string.IsNullOrEmpty(data))
				return new string[0];
			return data.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
		}

		public static void ReadIsolatedStorageStream(string filename, Action<IsolatedStorageFileStream> processAction)
		{
			ProcessIsolatedStorageStreamInternal(filename, true, processAction);
		}

		public static void WriteToIsolatedStorageStream(string filename, Action<IsolatedStorageFileStream> processAction)
		{
			ProcessIsolatedStorageStreamInternal(filename, false, processAction);
		}

		private static void ProcessIsolatedStorageStreamInternal(string filename, bool read, Action<IsolatedStorageFileStream> processAction)
		{
			if(read && !FileExists(filename)) return;

			var fileMode = read ? FileMode.Open : FileMode.Create;
			var fileAccess = read ? FileAccess.Read : FileAccess.Write;
			var fileShare = read ? FileShare.Read : FileShare.Write;
			ProcessIsolatedStorageFile(storageFile =>
			{
				using(var isolatedStorateFileStream = new IsolatedStorageFileStream(filename, fileMode, fileAccess, fileShare, storageFile))
				{
					processAction(isolatedStorateFileStream);
				}
			}
				);
		}

		public static void ProcessIsolatedStorageFile(Action<IsolatedStorageFile> processAction)
		{
			using(var storageFile = GetStorage())
			{
				processAction(storageFile);
			}
		}

		public static string Load(string filename)
		{
			string str = null;

			ReadIsolatedStorageStream(filename, isoStream =>
			{
				if(isoStream == null) return;

				using(var reader = new StreamReader(isoStream))
					str = reader.ReadToEnd();
			});

			return str;
		}

		public static byte[] LoadBytes(string fileName)
		{
			byte[] bytesResult = null;
			ReadIsolatedStorageStream(fileName, isoStream =>
			{
				if(isoStream == null) return;

				bytesResult = new byte[isoStream.Length];
				isoStream.Read(bytesResult, 0, (int)isoStream.Length);
			});
			return bytesResult;
		}

		public static T Load<T>(string filename)
		{
			var result = default( T );
			ReadIsolatedStorageStream(filename, isoStream =>
			{
				if(isoStream == null) return;

				var serializer = new XmlSerializer(typeof(T));
				result = (T)serializer.Deserialize(isoStream);
			});
			return result;
		}

		public static bool FileExists(string filename)
		{
			var fileExists = false;
			ProcessIsolatedStorageFile(isoFile => fileExists = isoFile.GetFileNames(filename).Length > 0);
			return fileExists;
		}

		public static void SaveLines(string filename, params string[] content)
		{
			var sb = new StringBuilder();
			foreach(var line in content)
				sb.AppendLine(line);

			Save(filename, sb.ToString());
		}

		public static void Save(string filename, byte[] bytes)
		{
			WriteToIsolatedStorageStream(filename, isoStream => isoStream.Write(bytes, 0, bytes.Length));
		}

		public static void Save(string filename, string content)
		{
			Save(filename, Encoding.UTF8.GetBytes(content));
		}

		public static void Save<T>(string filename, T content)
		{
			WriteToIsolatedStorageStream(filename, isoStream =>
			{
				var serializer = new XmlSerializer(content.GetType());
				serializer.Serialize(isoStream, content);
			});
		}

		public static void Delete(string filename)
		{
			if(!FileExists(filename))
			{
				//_log.Debug( "Delete: File Not Found: " + filename );
				return;
			}
			//_log.Debug( "Delete: Filename: " + filename );
			ProcessIsolatedStorageFile(storageFile => storageFile.DeleteFile(filename));
		}
	}
}