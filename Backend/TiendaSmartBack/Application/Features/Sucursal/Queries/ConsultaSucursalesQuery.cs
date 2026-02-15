using MediatR;
using TiendaSmartBack.Application.Features.Sucursal.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Sucursal.Queries
{
    public class ConsultaSucursalesQuery()
        : IRequest<ServiceResult<List<ResSucursalesActivasDTO>>>;
}
