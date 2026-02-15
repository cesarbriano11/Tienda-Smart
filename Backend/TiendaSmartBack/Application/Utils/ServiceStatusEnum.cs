namespace TiendaSmartBack.Application.Utils
{
    public enum ServiceStatusEnum
    {
        success = 200,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403, 
        NotFound = 404,
        DatabaseError = 502,
        InternalError = 500
    }
}
