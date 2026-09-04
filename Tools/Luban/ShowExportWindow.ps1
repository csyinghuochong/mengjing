# The PowerShell child shares the export console. Restore that console and
# request foreground focus before Luban starts printing diagnostics.
try {
    Add-Type -TypeDefinition @'
using System;
using System.Runtime.InteropServices;

public static class LubanExportWindow
{
    [DllImport("kernel32.dll")]
    public static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr window, int command);

    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr window);
}
'@ -ErrorAction Stop

    $exportWindow = [LubanExportWindow]::GetConsoleWindow()
    if ($exportWindow -ne [IntPtr]::Zero) {
        [void][LubanExportWindow]::ShowWindow($exportWindow, 9) # SW_RESTORE
        [void][LubanExportWindow]::SetForegroundWindow($exportWindow)
    }

    # Also request activation by title for terminal-hosted console windows.
    $exportShell = New-Object -ComObject WScript.Shell -ErrorAction Stop
    [void]$exportShell.AppActivate('Luban Config Export')
}
catch {
    # Focus is best-effort; a window-manager restriction must not block export.
    Write-Warning "Could not activate the export window: $($_.Exception.Message)"
}
