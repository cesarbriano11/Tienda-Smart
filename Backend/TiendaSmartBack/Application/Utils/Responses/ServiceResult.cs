namespace TiendaSmartBack.Application.Utils.Responses
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public ServiceStatusEnum Status { get; set; } = ServiceStatusEnum.success;
        public string? ErrorMessage { get; set; }
        public object ErrorData { get; set; } = new object();
        public T? Data { get; set; }

        public static ServiceResult<T> Ok(T data) =>
            new ServiceResult<T> { Success = true, Status = ServiceStatusEnum.success, Data = data };

        public static ServiceResult<T> Fail(string error, ServiceStatusEnum status = ServiceStatusEnum.BadRequest) =>
            new ServiceResult<T> {Success = false, Status = status, ErrorMessage = error};
        
    }
}
