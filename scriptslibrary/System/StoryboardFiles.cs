using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;
using System.IO;
using System;

public class StoryboardFiles
{
    public void CopyFiles(DirectoryInfo source, DirectoryInfo destination)
    {
        if(source == null)
            Directory.CreateDirectory(source.FullName);

        Directory.CreateDirectory(destination.FullName);
        foreach (FileInfo fileInfo in source.GetFiles())
        { 
            if(!File.Exists(Path.Combine(destination.FullName, fileInfo.Name)))
            {
                MainStoryboard.Instance.Log($"> {fileInfo.Name}");
                fileInfo.CopyTo(Path.Combine(destination.FullName, fileInfo.Name), true);
            }
        }
        foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
        {
            DirectoryInfo nextTargetSubDir =
                destination.CreateSubdirectory(diSourceSubDir.Name);
            CopyFiles(diSourceSubDir, nextTargetSubDir);
        }
    }
}