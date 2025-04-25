namespace ScalarWebApi
{
    public class WeatherForecast
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateOnly Date { get; set; }

        //攝氏溫度
        public int TemperatureC { get; set; }

        /// <summary>
        /// 華氏溫度
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// 總結
        /// </summary>
        public string? Summary { get; set; }
    }
}
