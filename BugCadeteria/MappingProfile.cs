using AutoMapper;
using ViewModel;
using Models;
using System.Data.SQLite;
public class MappingProfile : Profile
{
    public MappingProfile(){
        CreateMap<SaveCadeteVM, Cadete>().ReverseMap();
        CreateMap<UpdateCadeteVM, Cadete>().ReverseMap();
        CreateMap<ListCadetesVM, Cadete>().ReverseMap();

        CreateMap<SaveClienteVM, Cliente>().ReverseMap();
        CreateMap<UpdateClienteVM, Cliente>().ReverseMap();
        CreateMap<ListClientesVM, Cliente>().ReverseMap();

        CreateMap<SavePedidoVM, Pedido>().ReverseMap();
        CreateMap<SavePedidoVM, Cliente>().ReverseMap();

        CreateMap<IndexVM, Pedido>().ReverseMap();
    }
}
