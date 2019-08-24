using StorybrewScripts;
public class SpectrumSection : Section
{
    public SpectrumSection()
    {
        var spectrumManager = GetManager<SpectrumManager>();

        spectrumManager.SetupSprites();
        spectrumManager.CreateFakeSpectrum(33727,GetBeatDuration(0,0.5), 9,false);
        spectrumManager.CreateFakeSpectrum(87898,GetBeatDuration(0,0.5), 9,false);
    }
}