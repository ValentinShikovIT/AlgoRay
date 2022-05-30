using AlgoRay_Projector.Interfaces;

namespace AlgoRay_Projector
{
    internal class Settings : ISettings
    {
        bool ISettings.IsInProjectorTimeoutMode => true;

        int ISettings.DefaultTimeout => 1000;
    }
}
