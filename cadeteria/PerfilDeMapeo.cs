using AutoMapper;
using Models;
using ViewModel;

public class PerfilDeMapeo : Profile {
    public PerfilDeMapeo(){
        CreateMap<SaveCadeteVM, Cadete>();
        CreateMap<ListCadetesVM, Cadete>().ReverseMap();
        CreateMap<UpdateCadeteVM, Cadete>().ReverseMap();
    }
}