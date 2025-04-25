using Swashbuckle.AspNetCore.Filters;

namespace ScalarWebApi;

public class PushRequestModelExample:IMultipleExamplesProvider<PushRequestModel>
{
    public IEnumerable<SwaggerExample<PushRequestModel>> GetExamples()
    {
        yield return SwaggerExample.Create("情境1: 新增 (使用指定PID)", new PushRequestModel
        {
            Account = "D112132146",
            Channel = "3WK",
            UserIP = "1.2.3.4",
            PID = "1-202140820",
            Subject = "標題",
            Body = "內文",
            FunctionID = "1010005",
            PushData = "",
            NotifyAction = "10",
            MsgAction = "10",
            PushDate = "2024-08-20",
            PushTime = "15:10",
            CheckUser1 = "",
            CheckUser2 = "",
            UpdateUser = ""
        });
        
        yield return SwaggerExample.Create("情境2: 新增 (不指定PID)", new PushRequestModel
        {
            Account = "D112132146",
            Channel = "3WK",
            UserIP = "1.2.3.4",
            PID = "", // 空字串
            Subject = "標題",
            Body = "內文",
            FunctionID = "1010005",
            PushData = "",
            NotifyAction = "10",
            MsgAction = "10",
            PushDate = "2024-08-20",
            PushTime = "15:10",
            CheckUser1 = "",
            CheckUser2 = "",
            UpdateUser = ""
        });
        
        yield return SwaggerExample.Create("情境3: 更新", new PushRequestModel
        {
            Account = "D112132146",
            Channel = "3WK",
            UserIP = "1.2.3.4",
            PID = "1-202140820",
            Subject = "標題更新",
            Body = "內文",
            FunctionID = "1010005",
            PushData = "",
            NotifyAction = "10",
            MsgAction = "10",
            PushDate = "2024-08-20",
            PushTime = "15:10",
            CheckUser1 = "",
            CheckUser2 = "",
            UpdateUser = ""
        });
    }
}