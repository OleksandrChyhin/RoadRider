namespace RoadRiderClient.Core.Settings
{
    public interface IAppSettings
    {
        string BaseServerUrl { get; }
        string MapToken { get; }
    }
}
