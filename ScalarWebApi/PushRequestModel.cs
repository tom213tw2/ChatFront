namespace ScalarWebApi;

/// <summary>
/// 推播請求的資料模型
/// </summary>
public class PushRequestModel
{
    /// <summary>
    /// 使用者帳號，例如：D112132146
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 推播的通道代碼，例如：3WK
    /// </summary>
    public string Channel { get; set; }

    /// <summary>
    /// 使用者的 IP 位址，例如：1.2.3.4
    /// </summary>
    public string UserIP { get; set; }

    /// <summary>
    /// 個人識別碼（PID），通常用來對應身分或使用者，例如：1-202140820
    /// </summary>
    public string PID { get; set; }

    /// <summary>
    /// 推播的標題
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// 推播的內文內容
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// 功能代碼，用來識別是哪一個功能或模組呼叫此推播，例如：1010005
    /// </summary>
    public string FunctionID { get; set; }

    /// <summary>
    /// 附加資料（若無資料則為空字串）
    /// </summary>
    public string PushData { get; set; }

    /// <summary>
    /// 通知動作代碼（例如：10 代表某一種通知機制）
    /// </summary>
    public string NotifyAction { get; set; }

    /// <summary>
    /// 訊息處理動作代碼（例如：10 代表某一種訊息處理方式）
    /// </summary>
    public string MsgAction { get; set; }

    /// <summary>
    /// 預計推播日期，格式為 yyyy-MM-dd，例如：2024-08-20
    /// </summary>
    public string PushDate { get; set; }

    /// <summary>
    /// 預計推播時間，格式為 HH:mm，例如：15:10
    /// </summary>
    public string PushTime { get; set; }

    /// <summary>
    /// 第一位需覆核或審核的使用者帳號（可為空）
    /// </summary>
    public string CheckUser1 { get; set; }

    /// <summary>
    /// 第二位需覆核或審核的使用者帳號（可為空）
    /// </summary>
    public string CheckUser2 { get; set; }

    /// <summary>
    /// 最後更新資料的使用者帳號（可為空）
    /// </summary>
    public string UpdateUser { get; set; }
}
