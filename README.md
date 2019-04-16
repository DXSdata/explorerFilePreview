# explorerFilePreview
Enables Windows Explorer file preview for email files (.msg, .eml), without having Outlook installed.


## Notes
For HTML email preview, Renderer is used instead of WebBrowser (seems quite buggy).
If problems occur, discard Setup.msi and test with "Server Manager"; install both x86 and x64 (same DLL). Most times, however, one architecture seems to be enough.

### Debugging
[https://github.com/dwmkerr/sharpshell/wiki/Debugging-&-Diagnostics](https://github.com/dwmkerr/sharpshell/wiki/Debugging-&-Diagnostics)
Log mode has to be configured via srm.exe to be able to see the logs, and must be run in Server Manager via Test Shell.

### Console installation
[https://github.com/dwmkerr/sharpshell/wiki/srm:-Server-Registration-Manager](https://github.com/dwmkerr/sharpshell/wiki/srm:-Server-Registration-Manager)

See Codebase parameter(s).

### NuGet
For a successful install and registering, the DLLs must use "strong names", i.e. be signed. Therefore, an additional NuGet package is needed which signs MimeKit, HTML Renderer etc. after installation: StrongNameSigner.
Note this can cause issues with other NuGet packages (System.Security error etc.); in this case, temporarily uninstall the Signer.

## Other informational Links
[https://github.com/dwmkerr/sharpshell](https://github.com/dwmkerr/sharpshell)

[https://github.com/dwmkerr/sharpshell/issues/159](https://github.com/dwmkerr/sharpshell/issues/159)

[https://www.dxsdata.com/2019/04/explorerfilepreview/](https://www.dxsdata.com/2019/04/explorerfilepreview/)