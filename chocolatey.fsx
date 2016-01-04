// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake

// Properties
let cmdDir = "./build/exe/"
let guiDir = "./build/gui/"
let deployDir  = "./deploy/chocolatey/"
let packagingDir = "./packaging/"
let chocoDir = "./chocolatey/"

// version info
let version = environVar "version" // or retrieve from CI server

Target "Clean" (fun _ ->
    CleanDirs [deployDir; packagingDir]
)


Target "CreatePackage CMD" (fun _ ->
    CopyFiles packagingDir [
        cmdDir + "Autofac.dll";
        cmdDir + "AutoMapper.dll";
        cmdDir + "ClosedXML.dll";
        cmdDir + "DocumentFormat.OpenXml.dll";
        cmdDir + "Gherkin.dll";
        cmdDir + "MarkdownDeep.dll";
        cmdDir + "NDesk.Options.dll";
        cmdDir + "Newtonsoft.Json.dll";
        cmdDir + "NGenerics.dll";
        cmdDir + "NLog.dll";
        cmdDir + "PicklesDoc.Pickles.Library.dll";
        cmdDir + "PicklesDoc.Pickles.ObjectModel.dll";
        cmdDir + "PicklesDoc.Pickles.TestFrameworks.dll";
        cmdDir + "System.IO.Abstractions.dll";
        cmdDir + "pickles.exe";
        cmdDir + "NLog.config" ]

    WriteFile (packagingDir + "version.ps1") [("$version = \"" + version + "\"")]
    NuGet (fun p ->
        {p with
            OutputPath = deployDir
            WorkingDir = packagingDir
            Version = version
            Publish = false })
            (chocoDir + "Pickles.nuspec")
)


Target "CreatePackage GUI" (fun _ ->
    CopyFiles packagingDir [
        guiDir + "Autofac.dll";
        guiDir + "AutoMapper.dll";
        guiDir + "ClosedXML.dll";
        guiDir + "DocumentFormat.OpenXml.dll";
        guiDir + "GalaSoft.MvvmLight.dll";
        guiDir + "GalaSoft.MvvmLight.Extras.dll";
        guiDir + "GalaSoft.MvvmLight.Platform.dll";
        guiDir + "Gherkin.dll";
        guiDir + "MahApps.Metro.dll";
        guiDir + "MarkdownDeep.dll";
        guiDir + "Microsoft.Practices.ServiceLocation.dll";
        guiDir + "NDesk.Options.dll";
        guiDir + "Newtonsoft.Json.dll";
        guiDir + "NGenerics.dll";
        guiDir + "NLog.dll";
        guiDir + "NlogViewer.dll";
        guiDir + "Ookii.Dialogs.Wpf.dll";
        guiDir + "PicklesDoc.Pickles.Library.dll";
        guiDir + "PicklesDoc.Pickles.ObjectModel.dll";
        guiDir + "PicklesDoc.Pickles.TestFrameworks.dll";
        guiDir + "System.IO.Abstractions.dll";
        guiDir + "System.Windows.Interactivity.dll";
        guiDir + "picklesui.exe";
        guiDir + "NLog.config";
        guiDir + "PicklesUI.exe.config"]

    WriteFile (packagingDir + "version.ps1") [("$version = \"" + version + "\"")]
    WriteFile (packagingDir + "picklesui.exe.gui") [("")]
    NuGet (fun p ->
        {p with
            OutputPath = deployDir
            WorkingDir = packagingDir
            Version = version
            Publish = false })
            (chocoDir + "picklesui.nuspec")
)


Target "Default" (fun _ ->
    trace ("Starting build of Pickles version " + version)
    DeleteDir packagingDir
)


// Dependencies
"Clean"
  ==> "CreatePackage CMD"
  ==> "CreatePackage GUI"
  ==> "Default"


// start build
RunTargetOrDefault "Default"

