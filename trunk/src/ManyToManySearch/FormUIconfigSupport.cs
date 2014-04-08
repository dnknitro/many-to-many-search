using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using ManagedWinapi.Windows;

namespace ManyToManySearch
{
	public interface IAppBaseErrorHelperForm
	{
		event CancelEventHandler FormClosingChangesVerified;
	}

	public class CustomParamProvider
	{
		public string Key { get; set; }
		public Func<string> Getter { get; set; }
		public Action<string> Setter { get; set; }
	}

	public abstract class FormUIconfigSupportBase
	{
		private const string ATTR_ID = "id";
		private const string ATTR_VALUE = "value";
		private const string ATTR_UPDATED = "updated";
		private const string FILENAME = "FormUIconfigSupport.xml";

		private const string X_PARAM = "X";
		private const string Y_PARAM = "Y";
		private const string Width_PARAM = "Width";
		private const string Height_PARAM = "Height";
		private const string WindowState_PARAM = "WindowState";

		private class IdAndValue
		{
			private readonly string _id;
			private readonly string _val;
			private readonly DateTime _updated;

			public string Id
			{
				get { return _id; }
			}

			public string Val
			{
				get { return _val; }
			}

			public DateTime Updated
			{
				get { return _updated; }
			}

			public IdAndValue(string id, string val, DateTime updated)
			{
				_id = id;
				_val = val;
				_updated = updated;
			}
		}

		protected static readonly object _padlock = new object();
		private static Dictionary<string, IdAndValue> _geometryToValuesList = null;

		public event Action<Dictionary<string, string>> ValuesLoadedEvent;

		private readonly Dictionary<string, Func<string>> _standardParamProviders;
		private readonly List<CustomParamProvider> CustomParamProviders = new List<CustomParamProvider>();

		private Rectangle _beforeMaxMin = new Rectangle();
		protected string _formID = "FormUIconfigSupportBaseID";

		private static Dictionary<string, IdAndValue> GeometryList
		{
			get
			{
				lock(_padlock)
				{
					if(_geometryToValuesList == null)
						_geometryToValuesList = LoadValuesList();
					return _geometryToValuesList;
				}
			}
		}

		public void AddCustomParamProvider(string key, Func<string> getter)
		{
			AddCustomParamProvider(key, getter, null);
		}

		public void AddCustomParamProvider(Control control)
		{
			AddCustomParamProvider(control.Name, () => control.Text, loadedValue => control.Text = loadedValue);
		}

		public void AddCustomParamProvider(CheckBox checkBox)
		{
			AddCustomParamProvider(checkBox.Name, () => checkBox.Checked.ToString(), loadedValue => checkBox.Checked = bool.Parse(loadedValue));
		}

		public void AddCustomParamProvider(SplitContainer checkBox)
		{
			AddCustomParamProvider(checkBox.Name, () => checkBox.SplitterDistance.ToString(), loadedValue => checkBox.SplitterDistance = int.Parse(loadedValue));
		}

		public void AddCustomParamProvider(string key, Func<string> getter, Action<string> setter)
		{
			var provider = new CustomParamProvider {Key = key, Getter = getter, Setter = setter};
			CustomParamProviders.Add(new CustomParamProvider {Key = key, Getter = getter, Setter = setter});
			if(_loadedValues != null)
				ApplyCustomLoadedValues(_loadedValues, provider);
		}

		/// <summary>
		/// For unit tests only
		/// </summary>
		protected static void ClearGeometryList()
		{
			lock(_padlock)
				_geometryToValuesList = null;
		}

		protected FormUIconfigSupportBase()
		{
			_standardParamProviders =
				new Dictionary<string, Func<string>>
				{
					{X_PARAM, () => _beforeMaxMin.Location.X.ToString()},
					{Y_PARAM, () => _beforeMaxMin.Location.Y.ToString()},
					{Width_PARAM, () => _beforeMaxMin.Size.Width.ToString()},
					{Height_PARAM, () => _beforeMaxMin.Size.Height.ToString()},
					{WindowState_PARAM, () => GetCurrentWindowState().ToString()},
				};
		}

		protected abstract FormWindowState GetCurrentWindowState();

		protected abstract void ApplyLocation(Point location);

		protected abstract void ApplySize(Size size);

		protected abstract void ApplyWindowState(FormWindowState fws);

		private Dictionary<string, string> _loadedValues;

		protected void LoadAndApplyValues()
		{
			_loadedValues = new Dictionary<string, string>();
			if(GeometryList.ContainsKey(_formID))
			{
				_loadedValues = DeserializeValues(GeometryList[_formID].Val);

				ApplyLoadedValues(_loadedValues);
			}

			foreach(CustomParamProvider provider in CustomParamProviders)
			{
				ApplyCustomLoadedValues(_loadedValues, provider);
			}

			if(ValuesLoadedEvent != null)
				ValuesLoadedEvent(_loadedValues);
		}

		private void ApplyCustomLoadedValues(Dictionary<string, string> loadedValues, CustomParamProvider provider)
		{
			if(!loadedValues.ContainsKey(provider.Key) || provider.Setter == null) return;
			provider.Setter(loadedValues[provider.Key]);
		}

		private void ApplyLoadedValues(Dictionary<string, string> loadedValues)
		{
			//location
			if(!string.IsNullOrEmpty(loadedValues[X_PARAM]) && !string.IsNullOrEmpty(loadedValues[Y_PARAM]))
			{
				ApplyLocation(new Point(int.Parse(loadedValues[X_PARAM]), int.Parse(loadedValues[Y_PARAM])));
			}

			//size
			if(!string.IsNullOrEmpty(loadedValues[Width_PARAM]) && !string.IsNullOrEmpty(loadedValues[Height_PARAM]))
			{
				ApplySize(new Size(int.Parse(loadedValues[Width_PARAM]), int.Parse(loadedValues[Height_PARAM])));
			}

			//window state
			if(!string.IsNullOrEmpty(loadedValues[WindowState_PARAM]))
			{
				var windowString = loadedValues[WindowState_PARAM];

				ApplyWindowState(windowString == "Maximized" ? FormWindowState.Maximized : FormWindowState.Normal);
			}
		}

		protected void UpdateListWithCurrentValues()
		{
#if VERBOSE
			Log.Debug( string.Format( "UpdateListWithCurrentValue: geometryStr={0}", serializedValue ) );
#endif

			var g = new IdAndValue(_formID, SerializeCurrentValues(), DateTime.Now);
			lock(_padlock)
				GeometryList[g.Id] = g;
		}

		private Dictionary<string, string> GetCurrentValues()
		{
			var currentValues = new Dictionary<string, string>();
			foreach(var pair in _standardParamProviders)
				currentValues[pair.Key] = pair.Value();

			foreach(var pair in CustomParamProviders)
				currentValues[pair.Key] = pair.Getter();

			return currentValues;
		}

		private string SerializeCurrentValues()
		{
			var currentValues = from KeyValuePair<string, string> pair in GetCurrentValues()
				select string.Format("{0}={1}", pair.Key, HttpUtility.UrlEncode(pair.Value));

			return string.Join("&", currentValues);
		}

		/// <summary>
		/// deserializes parameters and sets windows size, location, state from saved values
		/// </summary>
		/// <param name="serializedValue"></param>
		private Dictionary<string, string> DeserializeValues(string serializedValue)
		{
#if VERBOSE
			Log.Debug( string.Format( "deserializing: serializedValue={0}", serializedValue ) );
#endif

			var loadedValues = new Dictionary<string, string>();
			foreach(var key in _standardParamProviders.Keys)
				loadedValues[key] = string.Empty;

			if(!string.IsNullOrEmpty(serializedValue))
			{
				var nameValueCollection = HttpUtility.ParseQueryString(serializedValue);
				foreach(string key in nameValueCollection.Keys)
				{
					if(!string.IsNullOrEmpty(key))
						loadedValues[key] = nameValueCollection[key];
				}
			}

			return loadedValues;
		}

		protected void SizeOrLocationChanged(Size size, Point location)
		{
			_beforeMaxMin.Size = size;
			_beforeMaxMin.Location = location;
		}

		/// <summary>
		/// loads geometries from file. If file doesn't exist - returns empty list of geometries, doesn't create the file
		/// </summary>
		private static Dictionary<string, IdAndValue> LoadValuesList()
		{
			var valuesList = new Dictionary<string, IdAndValue>();

			var xml = IsolatedStorageHelper.Load(FILENAME);

			if(string.IsNullOrEmpty(xml)) return valuesList;

			var doc = new XmlDocument();
			try
			{
				doc.LoadXml(xml);
			}
			catch(XmlException)
			{
				//Log.Warn(ex.Message, ex);
				IsolatedStorageHelper.Delete(FILENAME);
				return valuesList;
			}

			if(doc.DocumentElement == null)
			{
				//Log.Warn("doc.DocumentElement == null");
				return valuesList;
			}

			foreach(XmlNode node in doc.DocumentElement.GetElementsByTagName("formGeometry"))
			{
				if(node.Attributes[ATTR_ID] == null || node.Attributes[ATTR_VALUE] == null || node.Attributes[ATTR_UPDATED] == null)
					//skip erroneous nodes
					continue;

				var g = new IdAndValue(node.Attributes[ATTR_ID].Value, node.Attributes[ATTR_VALUE].Value,
					DateTime.Parse(node.Attributes[ATTR_UPDATED].Value));
				valuesList.Add(g.Id, g);
			}

			return valuesList;
		}

		/// <summary>
		/// Saves the windows configuration to disk.
		/// </summary>
		public static void SaveGeometryList()
		{
			lock(_padlock)
			{
				//create xml and write it
				var doc = new XmlDocument();
				doc.LoadXml("<formGeometries></formGeometries>");

				if(doc.DocumentElement != null)
				{
					foreach(KeyValuePair<string, IdAndValue> pair in GeometryList)
					{
						XmlNode node = doc.CreateElement("formGeometry");
						node.Attributes.Append(doc.CreateAttribute(ATTR_ID));
						node.Attributes.Append(doc.CreateAttribute(ATTR_VALUE));
						node.Attributes.Append(doc.CreateAttribute(ATTR_UPDATED));
						node.Attributes[ATTR_ID].Value = pair.Value.Id;
						node.Attributes[ATTR_VALUE].Value = pair.Value.Val;
						node.Attributes[ATTR_UPDATED].Value = pair.Value.Updated.ToString();
						doc.DocumentElement.AppendChild(node);
					}

					IsolatedStorageHelper.Save(FILENAME, doc.OuterXml);
				}
			}
		}

		public static string ScreensGeometryToString()
		{
			var screensGeometry = "";
			foreach(Screen s in Screen.AllScreens)
				screensGeometry += s.WorkingArea;
			return screensGeometry;
		}
	}

	public class FormUIconfigSupport : FormUIconfigSupportBase
	{
		public const string HORIZONTAL_SPLITTER_DISTANCE_KEY = "HorizontalSplitterDistance";

		private static bool _applicationExitSet;
		private readonly SystemWindow _systemWindow;


		public FormUIconfigSupport(Form form)
		{
			if(ManyToManySearchProgram.IsDesignTime) return;

			//Form's location, size and WindowState of the form is stored on per _formID basis
			//_formID is generated from form's type name and ScreensGeometry configuration
			//Thus it is unique per different screen resolutions and multy monitors configuration
			_formID = form.GetType().Name + Regex.Replace(ScreensGeometryToString(), "[{},=]", string.Empty);

			lock(_padlock)
			{
				if(!_applicationExitSet)
				{
					_applicationExitSet = true;
					Application.ApplicationExit += ApplicationExitHandler;
				}
			}

			_systemWindow = new SystemWindow(form.Handle);

			form.Load += Form_Load;

			if(form is IAppBaseErrorHelperForm)
				( (IAppBaseErrorHelperForm)form ).FormClosingChangesVerified += Form_Closing;
			form.Resize += Form_ResizeOrLocationChanged;
			form.LocationChanged += Form_ResizeOrLocationChanged;
		}


		private void ApplicationExitHandler(object sender, EventArgs e)
		{
			SaveGeometryList();
		}


		protected override void ApplyLocation(Point location)
		{
			_systemWindow.Location = location;
		}


		protected override void ApplySize(Size size)
		{
			_systemWindow.Size = size;
		}


		protected override void ApplyWindowState(FormWindowState fws)
		{
			_systemWindow.WindowState = fws;
		}


		protected override FormWindowState GetCurrentWindowState()
		{
			return _systemWindow.WindowState;
		}


		private void Form_Load(object sender, EventArgs e)
		{
			LoadAndApplyValues();

			( (Form)sender ).Closing += Form_Closing;
		}


		private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			UpdateListWithCurrentValues();
		}


		private void Form_ResizeOrLocationChanged(object sender, EventArgs e)
		{
			var form = (Form)sender;
			if(!( form.WindowState == FormWindowState.Maximized || form.WindowState == FormWindowState.Minimized ))
			{
				SizeOrLocationChanged(form.Size, form.Location);
			}
		}
	}
}