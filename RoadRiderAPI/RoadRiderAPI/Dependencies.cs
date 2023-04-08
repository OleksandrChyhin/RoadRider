namespace RoadRiderAPI
{
    public static class Dependencies
    {
        public static void RegisterServices(IServiceCollection services)
        {
           services.AddControllers();           
           services.AddEndpointsApiExplorer();
           services.AddSwaggerGen();
        }

    }
}
