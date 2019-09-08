using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace StorybrewScripts
{
    public class MainStoryboard : StoryboardObjectGenerator
    {
        #region Singleton
        private static MainStoryboard _instance = null;
        public static MainStoryboard Instance 
        { 
            get 
            {
                if(_instance == null)
                    _instance = new MainStoryboard();

                return _instance; 
            }
        }
        #endregion
        public ManagerLocator Locator = new ManagerLocator();
        private StoryboardFiles storyboardFiles = new StoryboardFiles();
        private DirectoryInfo mapsetDirectory, projectDirectory;
        [Configurable] public bool Refresh;
        [Configurable] public bool CopySprites = true;
        public override void Generate()
        {
            _instance = this;
            ManageFiles();

            //REGISTER YOUR MANAGERS ABOVE THIS//
            Locator.Register<BackgroundManager>(new BackgroundManager());
            Locator.Register<ExampleManager>(new ExampleManager());
            Locator.Register<ParticleManager>(new ParticleManager());
            Locator.Register<CreditManager>(new CreditManager());
            Locator.Register<ForegroundManager>(new ForegroundManager());
            Locator.Register<LyricManager>(new LyricManager());
            Locator.Register<TransitionManager>(new TransitionManager());
            Locator.Register<OsbManager>(new OsbManager());
            
            //INSTANCIATE YOUR SECTIONS IN THIS ARRAY//
            Section[] instanciatedSections =
            {
                new BackgroundSection(),
                new ExampleSection(),
                new ParticleSection(),
                new CreditSection(),                
                new OsbSection(),
                new ForegroundSection(),
                new TransitionSection(),
                
            };
        }
        private void ManageFiles()
        {
            if(CopySprites)
            {
                Log("--- COPY FROM PROJECT ---");
                mapsetDirectory = new DirectoryInfo(MapsetPath + "/sb");
                projectDirectory = new DirectoryInfo(ProjectPath + "/sprites");
                storyboardFiles.CopyFiles(projectDirectory, mapsetDirectory);
                Log(" ");
                Log("--- COPY FROM MAPSET ---");
                storyboardFiles.CopyFiles(mapsetDirectory, projectDirectory);
                Log(" ");
            }
            else 
            {
                Log("--- FILE COPY DISABLED ---");
                Log(" ");
            }
        }
    }
}