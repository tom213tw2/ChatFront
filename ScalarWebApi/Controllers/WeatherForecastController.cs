using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace ScalarWebApi.Controllers
{
    [ApiController]
    // [Route("[controller]")]
    [Route("api")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GetAllData
        /// </summary>
        /// <remarks>
        /// - One
        /// - Two
        /// - Three
        /// ### 情境1: 新增 (使用指定PID)
        /// ```
        /// {
        ///  "Account":"D112132146","Channel":"3WK","UserIP":"1.2.3.4"
        /// ,"PID": "1-202140820"
        /// ,"Subject": "標題"
        /// ,"Body": "內文"
        /// ,"FunctionID": "1010005"
        /// ,"PushData": ""
        /// ,"NotifyAction": "10"
        /// ,"MsgAction": "10"
        /// ,"PushDate": "2024-08-20"
        /// ,"PushTime": "15:10"
        /// ,"CheckUser1": ""
        /// ,"CheckUser2": ""
        /// ,"UpdateUser": ""
        /// }
        /// ```
        /// 
        /// ### 情境2: 新增 (不指定PID)
        /// ```
        /// {
        ///  "Account":"D112132146","Channel":"3WK","UserIP":"1.2.3.4"
        /// ,"PID": ""
        /// ,"Subject": "標題"
        /// ,"Body": "內文"
        /// ,"FunctionID": "1010005"
        /// ,"PushData": ""
        /// ,"NotifyAction": "10"
        /// ,"MsgAction": "10"
        /// ,"PushDate": "2024-08-20"
        /// ,"PushTime": "15:10"
        /// ,"CheckUser1": ""
        /// ,"CheckUser2": ""
        /// ,"UpdateUser": ""
        /// }
        /// ```
        /// 
        /// ### 情境3: 更新
        /// ```
        /// {
        ///  "Account":"D112132146","Channel":"3WK","UserIP":"1.2.3.4"
        /// ,"PID": "1-202140820"
        /// ,"Subject": "標題更新"
        /// ,"Body": "內文"
        /// ,"FunctionID": "1010005"
        /// ,"PushData": ""
        /// ,"NotifyAction": "10"
        /// ,"MsgAction": "10"
        /// ,"PushDate": "2024-08-20"
        /// ,"PushTime": "15:10"
        /// ,"CheckUser1": ""
        /// ,"CheckUser2": ""
        /// ,"UpdateUser": ""
        /// }
        /// ```
        /// ### 情境2: 取得客戶指定帳號-帳務類電子報客戶訂閱選
        /// |欄位名稱|描述|
        /// |-----|-----|
        /// |Account|使用者帳號資訊|
        /// |BrkID|分公司代號|
        /// |CstAccount|帳號|
        /// |Category|類別(1,4:複委託)|
        /// 
        /// ```
        /// {
        ///    "Account": "A110000004",
        ///    "BrkID": "9887",
        ///    "CstAccount": "5002227",
        ///    "Category": "1"
        /// }
        /// ```
        ///
        /// ### 回傳
        /// |欄位名稱|描述|
        /// |-----|-----|
        /// |Account|使用者帳號資訊|
        /// |BrkID|分公司代號|
        /// |CstAccount|帳號|
        /// |CstName|客戶姓名|
        /// |Category|類別(1,4:複委託)|
        /// |Email|信箱|
        /// |Privacynotice|隱私條款|
        /// |Epaper_0001 |台股即時成交回報|
        /// |Epaper_0002 |台股每日成交回報|
        /// |Epaper_0003 |台股每日投資明細 |
        /// |Epaper_0004 |股整戶維持率通知|
        /// |Epaper_0005 |外國有價證券每日交易明細|
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("GetWeatherForecast")]
        [SwaggerRequestExample(typeof(PushRequestModel), typeof(PushRequestModelExample))]
        public IEnumerable<WeatherForecast> Get([FromBody] PushRequestModel modal)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }

        /// <summary>
        /// GetAllDataV2
        /// </summary>
        /// <remarks>
        ///
        /// ### 回傳
        /// |欄位名稱|描述|
        /// |-----|-----|
        /// |Account|使用者帳號資訊|
        /// |BrkID|分公司代號|
        /// |CstAccount|帳號|
        /// |CstName|客戶姓名|
        /// |Category|類別(1,4:複委託)|
        /// |Email|信箱|
        /// |Privacynotice|隱私條款|
        /// |Epaper_0001 |台股即時成交回報|
        /// |Epaper_0002 |台股每日成交回報|
        /// |Epaper_0003 |台股每日投資明細 |
        /// |Epaper_0004 |股整戶維持率通知|
        /// |Epaper_0005 |外國有價證券每日交易明細|
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWeatherForecastV2")]
        public IEnumerable<WeatherForecast> GetV2()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }

    public class QueryEPaperInformationModal : BaseModel
    {
        /// <summary>
        /// 身份證 統編
        /// </summary>
        public string Eid { get; set; }

        /// <summary>
        ///  4碼分公司代號
        /// </summary>
        public string BrkID { get; set; }

        /// <summary>
        /// 7碼帳號	
        /// </summary>
        public string CstAccount { get; set; }

        /// <summary>
        /// 類別(1,4:複委託)
        /// </summary>
        public string Category { get; set; }
    }

    /// <summary>
    /// 會完全共用到的屬性
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 使用者帳號資訊 
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 呼叫端使用頻道
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 呼叫端使用者IP
        /// </summary>
        public string UserIP { get; set; }

        /// <summary>
        /// 呼叫端系統名稱 (會紀錄到 Client_CustomData )
        /// </summary>
        public string SystemID { get; set; }

        /// <summary>
        /// 快取的執行動作 預設為 0 ; 
        /// 0 = 預設行為按照API流程執行; 
        /// 1 = NonCache 不要快取，直接讀資料庫(源)傳回 ; 
        /// 2 = RefreshCache 強迫 RefreshCache 重新取資料並且更新快取 
        /// </summary>
        public int CacheAction { get; set; }

        /// <summary>
        /// 用來驗證EC後端系列-類似密碼TOKEN化概念
        /// </summary>
        public string AuthHash { get; set; } = string.Empty;

        /// <summary>
        /// 用於驗證查詢 Account-類似帳號TOKEN化概念
        /// </summary>
        public string PrivateHash { get; set; } = string.Empty;
    }

    public class QueryEPaperInformationModalExample : IMultipleExamplesProvider<QueryEPaperInformationModal>
    {
        public IEnumerable<SwaggerExample<QueryEPaperInformationModal>> GetExamples()
        {
            yield return SwaggerExample.Create("Default", new QueryEPaperInformationModal
            {
                Account = "A110000004",
                BrkID = "9887",
                CstAccount = "5002227",
                Category = "1"
            });

            yield return SwaggerExample.Create("Default2", new QueryEPaperInformationModal
            {
                Account = "A110000004",
                BrkID = "9887",
                CstAccount = "5002245",
                Category = "2"
            });
        }
    }
}