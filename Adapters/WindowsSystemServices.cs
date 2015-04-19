using System.Diagnostics;
using System.IO;
using System.Windows;
using Ports;
using Ports.Interfaces;

namespace Adapters
{
  public class WindowsSystemServices : SystemServices
  {
    private bool _fileExists;
    private const byte ShellCopy = 5;

    public void AddToClipboard(ChangedPath fullPath)
    {
      using (var stream = CreateCopyDescription())
      {
        IDataObject data = new DataObject();
        data.SetData(DataFormats.FileDrop, new[] {fullPath.ToString()}, true);
        data.SetData("Preferred DropEffect", stream);
        Clipboard.Clear();
        Clipboard.SetDataObject(data, true);
      }
    }

    private static MemoryStream CreateCopyDescription()
    {
      var stream = new MemoryStream(4);
      var clipboardOperationDescription = new byte[] { ShellCopy, 0, 0, 0 };
      stream.Write(clipboardOperationDescription, 0, clipboardOperationDescription.Length);
      stream.SetLength(clipboardOperationDescription.Length);

      return stream;
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
        MessageBox.Show(fullPath + " does not exist anymore");
        MessageBox.Show(fullPath + " does not exist anymore");
      }
      return _fileExists;
    }
  }
}