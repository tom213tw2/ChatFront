using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swashbuckle.AspNetCore.Filters;

namespace ScalarWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        /// ### ����1: �s�W (�ϥΫ��wPID)
        /// ```
        /// {
        ///  "Account":"D112132146","Channel":"3WK","UserIP":"1.2.3.4"
        /// ,"PID": "1-202140820"
        /// ,"Subject": "���D"
        /// ,"Body": "����"
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
        /// ### ����2: �s�W (�����wPID)
        /// ```
        /// {
        ///  "Account":"D112132146","Channel":"3WK","UserIP":"1.2.3.4"
        /// ,"PID": ""
        /// ,"Subject": "���D"
        /// ,"Body": "����"
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
        /// ### ����3: ��s
        /// ```
        /// {
        ///  "Account":"D112132146","Channel":"3WK","UserIP":"1.2.3.4"
        /// ,"PID": "1-202140820"
        /// ,"Subject": "���D��s"
        /// ,"Body": "����"
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
        /// ### ����2: ���o�Ȥ���w�b��-�b�����q�l���Ȥ�q�\��
        /// |���W��|�y�z|
        /// |-----|-----|
        /// |Account|�ϥΪ̱b����T|
        /// |BrkID|�����q�N��|
        /// |CstAccount|�b��|
        /// |Category|���O(1,4:�Ʃe�U)|
        /// ```
        /// {
        ///    "Account": "A110000004",
        ///    "BrkID": "9887",
        ///    "CstAccount": "5002227",
        ///    "Category": "1"
        /// }
        /// ```
        ///
        /// ### �^��
        /// |���W��|�y�z|
        /// |-----|-----|
        /// |Account|�ϥΪ̱b����T|
        /// |BrkID|�����q�N��|
        /// |CstAccount|�b��|
        /// |CstName|�Ȥ�m�W|
        /// |Category|���O(1,4:�Ʃe�U)|
        /// |Email|�H�c|
        /// |Privacynotice|���p����|
        /// |Epaper_0001 |�x�ѧY�ɦ���^��|
        /// |Epaper_0002 |�x�ѨC�馨��^��|
        /// |Epaper_0003 |�x�ѨC������� |
        /// |Epaper_0004 |�Ѿ������v�q��|
        /// |Epaper_0005 |�~�꦳���Ҩ�C��������|
        /// </remarks>
        /// <returns></returns>
        [HttpPost(Name = "GetWeatherForecast")]
        [SwaggerRequestExample(typeof(QueryEPaperInformationModal),typeof(QueryEPaperInformationModalExample))]
        [SwaggerRequestExample(typeof(QueryEPaperInformationModal),typeof(QueryEPaperInformationModalExample))]
        
        public IEnumerable<WeatherForecast> Get([FromBody] QueryEPaperInformationModal modal)
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

    public class QueryEPaperInformationModal: BaseModel
    {
        /// <summary>
        /// ������ �νs
        /// </summary>
        public string Eid { get; set; }

        /// <summary>
        ///  4�X�����q�N��
        /// </summary>
        public string BrkID { get; set; }

        /// <summary>
        /// 7�X�b��	
        /// </summary>
        public string CstAccount { get; set; }

        /// <summary>
        /// ���O(1,4:�Ʃe�U)
        /// </summary>
        public string Category { get; set; }
    }

    /// <summary>
    /// �|�����@�Ψ쪺�ݩ�
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// �ϥΪ̱b����T 
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// �I�s�ݨϥ��W�D
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// �I�s�ݨϥΪ�IP
        /// </summary>
        public string UserIP { get; set; }
        /// <summary>
        /// �I�s�ݨt�ΦW�� (�|������ Client_CustomData )
        /// </summary>
        public string SystemID { get; set; }
        /// <summary>
        /// �֨�������ʧ@ �w�]�� 0 ; 
        /// 0 = �w�]�欰����API�y�{����; 
        /// 1 = NonCache ���n�֨��A����Ū��Ʈw(��)�Ǧ^ ; 
        /// 2 = RefreshCache �j�� RefreshCache ���s����ƨåB��s�֨� 
        /// </summary>
        public int CacheAction { get; set; }

        /// <summary>
        /// �Ψ�����EC��ݨt�C-�����K�XTOKEN�Ʒ���
        /// </summary>
        public string AuthHash { get; set; } = string.Empty;

        /// <summary>
        /// �Ω����Ҭd�� Account-�����b��TOKEN�Ʒ���
        /// </summary>
        public string PrivateHash { get; set; } = string.Empty;

    }

    public class QueryEPaperInformationModalExample: IExamplesProvider<QueryEPaperInformationModal>
    {
        public QueryEPaperInformationModal GetExamples()
        {
            return new QueryEPaperInformationModal
            {
                Account = "A110000004",
                BrkID = "9887",
                CstAccount = "5002227",
                Category = "1"
            };
        }
    }
}
