namespace Api_Code.Service
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetForcast();
    }
}
