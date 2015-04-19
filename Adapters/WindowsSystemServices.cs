using System.Diagnostics;
using System.Windows;
using Ports;

namespace Adapters
{
  public class WindowsSystemServices : SystemServices
  {
    private bool _fileExists;

    public void AddToClipboard(ChangedPath fullPath)
    {
      var objData = new DataObject();
      objData.SetData(DataFormats.FileDrop, new[] {fullPath}, false);
      Clipboard.SetDataObject(objData, true);
    }

    public void StartExplorer(ChangedPath fullPath)
    {
      Process.Start("explorer.exe", "/select," + fullPath + "\"");
    }

    public bool PathExists(ChangedPath fullPath)
    {
      _fileExists = fullPath.ToFileInfo().Exists;
      if (!_fileExists)
      {
        MessageBox.Show(fullPath + " does not exist");
        MessageBox.Show(fullPath + " does not exist");
      }
      return _fileExists;
    }
  }
}