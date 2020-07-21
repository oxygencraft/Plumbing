#if UNITY_EDITOR
//////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2014 Audiokinetic Inc. / All Rights Reserved
//
//////////////////////////////////////////////////////////////////////

public class AkWwiseXMLWatcher
{
	private static readonly AkWwiseXMLWatcher instance = new AkWwiseXMLWatcher();
	public static AkWwiseXMLWatcher Instance { get { return instance; } }

	private System.IO.FileSystemWatcher XmlWatcher;
	private bool ExceptionOccurred;
	private bool fireEvent;

	public event System.Action XMLUpdated;
	public System.Func<bool> PopulateXML;

	private AkWwiseXMLWatcher()
	{
		XmlWatcher = new System.IO.FileSystemWatcher{ Filter = "*.xml", IncludeSubdirectories = true, };

		try
		{
			// Event handlers that are watching for specific event
			XmlWatcher.Created += RaisePopulateFlag;
			XmlWatcher.Changed += RaisePopulateFlag;

			XmlWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
			XmlWatcher.EnableRaisingEvents = true;
			XmlWatcher.Path = AkBasePathGetter.GetPlatformBasePath();
		}
		catch
		{
			ExceptionOccurred = true;
		}

		UnityEditor.EditorApplication.update += OnEditorUpdate;
	}

	private void OnEditorUpdate()
	{
		var logWarnings = AkBasePathGetter.LogWarnings;
		AkBasePathGetter.LogWarnings = false;
		var path = AkBasePathGetter.GetPlatformBasePath();
		AkBasePathGetter.LogWarnings = logWarnings;

		try
		{
			if (ExceptionOccurred || path != XmlWatcher.Path)
				XmlWatcher.Path = path;

			ExceptionOccurred = false;
		}
		catch
		{
			ExceptionOccurred = true;
		}

		if (!fireEvent)
			return;

		fireEvent = false;

		var populate = PopulateXML;
		if (populate == null || !populate())
			return;

		var callback = XMLUpdated;
		if (callback != null)
		{
			callback();
		}

		AkBankManager.ReloadAllBanks();
	}

	private void RaisePopulateFlag(object sender, System.IO.FileSystemEventArgs e)
	{
		fireEvent = true;
	}
}
#endif
