namespace AlgoRay_Projector.Interfaces
{
    internal interface ISettings
    {
        public bool IsInProjectorTimeoutMode { get; }
        public int DefaultTimeout { get; }
    }
}
