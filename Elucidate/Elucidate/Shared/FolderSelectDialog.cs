using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

// ------------------------------------------------------------------
// Wraps System.Windows.Forms.OpenFileDialog to make it present
// a vista-style dialog.
// ------------------------------------------------------------------

namespace Elucidate.Shared;

/// <summary>
/// Wraps System.Windows.Forms.OpenFileDialog to make it present
/// a vista-style dialog.
/// </summary>
/// <remarks>
/// Stolen from https://stackoverflow.com/questions/11767/browse-for-a-directory-in-c-sharp
/// and then fixed via ReSharper
/// </remarks>
public class FolderSelectDialog
{
    private string initialDirectory;

    public string InitialDirectory
    {
        private get => string.IsNullOrEmpty(initialDirectory) ? Environment.CurrentDirectory : initialDirectory;
        set => initialDirectory = value;
    }

    public string TargetDirectory { private get; set; }

    public string Title { private get; set; } = @"Select a folder";

    public string FileName { get; private set; } = string.Empty;

    /// <param name="hWndOwner">Handle of the control or window to be the parent of the file dialog</param>
    /// <returns>true if the user clicks OK</returns>
    public bool ShowDialog(IWin32Window hWndOwner = null)
    {
        IntPtr hIntOwner = IntPtr.Zero;
        if (hWndOwner != null)
        {
            hIntOwner = GetSafeHandle(hWndOwner);
        }

        if (hIntOwner == IntPtr.Zero)
        {
            hIntOwner = GetActiveWindow();
        }
        ShowDialogResult result = Environment.OSVersion.Version.Major >= 6
            ? VistaDialog.Show(hIntOwner, InitialDirectory, Title, TargetDirectory)
            : ShowXpDialog(hIntOwner, InitialDirectory, Title);
        FileName = result.FileName;
        return result.Result;
    }

    private struct ShowDialogResult
    {
        public bool Result { get; set; }
        public string FileName { get; set; }
    }

    private static ShowDialogResult ShowXpDialog(IntPtr ownerHandle, string initialDirectory, string title)
    {
        var folderBrowserDialog = new FolderBrowserDialog
        {
            Description = title,
            SelectedPath = initialDirectory,
            ShowNewFolderButton = true
        };
        var dialogResult = new ShowDialogResult();
        if (folderBrowserDialog.ShowDialog(new WindowWrapper(ownerHandle)) == DialogResult.OK)
        {
            dialogResult.Result = true;
            dialogResult.FileName = folderBrowserDialog.SelectedPath;
        }
        return dialogResult;
    }

    private static class VistaDialog
    {
        private const string FOLDERS_FILTER = "Folders|\n";

        private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        private static readonly Assembly WindowsFormsAssembly = typeof(FileDialog).Assembly;
        private static readonly Type IFileDialogType = WindowsFormsAssembly.GetType("System.Windows.Forms.FileDialogNative+IFileDialog");
        private static readonly MethodInfo CreateVistaDialogMethodInfo = typeof(OpenFileDialog).GetMethod("CreateVistaDialog", FLAGS);
        private static readonly MethodInfo OnBeforeVistaDialogMethodInfo = typeof(OpenFileDialog).GetMethod("OnBeforeVistaDialog", FLAGS);
        private static readonly MethodInfo GetOptionsMethodInfo = typeof(FileDialog).GetMethod("GetOptions", FLAGS);
        private static readonly MethodInfo SetOptionsMethodInfo = IFileDialogType.GetMethod("SetOptions", FLAGS);
        private static readonly uint FosPickFoldersBitFlag = (uint)WindowsFormsAssembly
            .GetType("System.Windows.Forms.FileDialogNative+FOS")
            .GetField("FOS_PICKFOLDERS")
            .GetValue(null);
        private static readonly ConstructorInfo VistaDialogEventsConstructorInfo = WindowsFormsAssembly
            .GetType("System.Windows.Forms.FileDialog+VistaDialogEvents")
            .GetConstructor(FLAGS, null, new[] { typeof(FileDialog) }, null);
        private static readonly MethodInfo AdviseMethodInfo = IFileDialogType.GetMethod("Advise");
        private static readonly MethodInfo UnAdviseMethodInfo = IFileDialogType.GetMethod("Unadvise");
        private static readonly MethodInfo ShowMethodInfo = IFileDialogType.GetMethod("Show");

        public static ShowDialogResult Show(IntPtr ownerHandle, string initialDirectory, string title, string targetDirectory)
        {
            var openFileDialog = new OpenFileDialog
            {
                AddExtension = false,
                CheckFileExists = false,
                DereferenceLinks = true,
                Filter = FOLDERS_FILTER,
                InitialDirectory = initialDirectory,
                Multiselect = false,
                Title = title,
                FileName = targetDirectory,
                AutoUpgradeEnabled = true,
                ValidateNames = true
            };

            var iFileDialog = CreateVistaDialogMethodInfo.Invoke(openFileDialog, Array.Empty<object>());
            OnBeforeVistaDialogMethodInfo.Invoke(openFileDialog, new[] { iFileDialog });
            SetOptionsMethodInfo.Invoke(iFileDialog, new object[] { (uint)GetOptionsMethodInfo.Invoke(openFileDialog, Array.Empty<object>()) | FosPickFoldersBitFlag });
            var adviseParametersWithOutputConnectionToken = new[] { VistaDialogEventsConstructorInfo.Invoke(new object[] { openFileDialog }), 0U };
            AdviseMethodInfo.Invoke(iFileDialog, adviseParametersWithOutputConnectionToken);

            try
            {
                var retVal = (int)ShowMethodInfo.Invoke(iFileDialog, new object[] { ownerHandle });
                return new ShowDialogResult
                {
                    Result = retVal == 0,
                    FileName = openFileDialog.FileName
                };
            }
            finally
            {
                UnAdviseMethodInfo.Invoke(iFileDialog, new[] { adviseParametersWithOutputConnectionToken[1] });
            }
        }
    }

    // Wrap an IWin32Window around an IntPtr
    private class WindowWrapper : IWin32Window
    {
        public WindowWrapper(IntPtr handle) { Handle = handle; }
        public IntPtr Handle { get; }
    }

    private static IntPtr GetSafeHandle(IWin32Window window)
    {
        if (window is Control control)
        {
            return control.Handle;
        }

        return window.Handle;
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static extern IntPtr GetActiveWindow();
}
